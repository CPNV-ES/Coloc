using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coloc.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authorization;

namespace Coloc.Controllers
{
    public class AspNetUsersController : Controller
    {
        private readonly ColocContext _context;

        public AspNetUsersController(ColocContext context)
        {
            _context = context;
        }

        // GET: AspNetUsers
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
           // List users with their role
           return View(await _context.AspNetUsers
                .Include(r => r.AspNetUserRoles)
                .ThenInclude(s => s.Role)
                .ToListAsync());
        }

        // GET: AspNetUsers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // If a user try to access another user detail page, redirect to his own detail page
            var currentRole = User.FindFirstValue(ClaimTypes.Role);
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentRole == "User" && currentUserId != id)
            {
                return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "AspNetUsers", action = "Details", Id = currentUserId }));
            }

            string userId = id;
            // Can remove aspNetUsers2
            var aspNetUsers = await _context.AspNetUsers
                .Include(r => r.UserTasks)
                .ThenInclude(s => s.Task)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }
            var userTasks = await _context.UserTasks
                .FirstOrDefaultAsync(m => m.UserId == id);

            // If the user has no tasks, return an empty view
            if (userTasks == null)
            {
                var tuple2 = new Tuple<AspNetUsers, UserTasks>(aspNetUsers, null);
                return View(tuple2);
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks.OrderBy(r => r.Todo), "Id", "Description", userTasks.TaskId);

            //  Change the task of a user. List in a format: Todo - Task
            ViewData["TaskId"] = from u in _context.Tasks.OrderBy(r => r.Title).OrderBy(r => r.Todo)
                                 select new SelectListItem
                                 {
                                     Value = u.Id.ToString(),
                                     Text = u.Todo.Title + " - " + u.Title
                                 };
            var tuple = new Tuple<AspNetUsers, UserTasks>(aspNetUsers, null);
            return View(tuple);
        }

        // Method to get our personnal tasks
        public IActionResult MyTasks()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get current user logged in
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "AspNetUsers", action = "Details", Id = userId }));

        }

        // GET: AspNetUsers/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: AspNetUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUsers aspNetUsers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aspNetUsers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUsers);
        }


        // GET: AspNetUsers/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers
                .Include(r => r.AspNetUserRoles)
                .ThenInclude(s => s.Role)
                //.ToListAsync();
                .FirstOrDefaultAsync(m => m.Id == id);

            //  List all roles disponible

            var currentRole = _context.AspNetUserRoles.Where(r => r.UserId == id).FirstOrDefault().Role;
            ViewData["SelectedRole"] = currentRole.Id;
            ViewData["Roles"] = _context.AspNetRoles;

            if (aspNetUsers == null)
            {
                return NotFound();
            }
            return View(aspNetUsers);
        }


        // Update role
        // POST: AspNetUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] AspNetUsers aspNetUsers)
        {
            if (id != aspNetUsers.Id)
            {
                return NotFound();
            }

            // Admin can't change his own role
            var currentRole = User.FindFirstValue(ClaimTypes.Role);
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (currentRole == "Admin" && currentUserId == id)
            {
                return RedirectToAction("Index", new RouteValueDictionary(
                    new { controller = "AspNetUsers", action = "Index"}));
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var newRoleId = Request.Form["Role"];
                    var currentUsersRoles = _context.AspNetUserRoles.Where(r => r.UserId == aspNetUsers.Id).FirstOrDefault();

                    var newRole = new AspNetUserRoles { RoleId = newRoleId, UserId = id };

                    _context.Remove(currentUsersRoles);
                    _context.Add(newRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AspNetUsersExists(aspNetUsers.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(aspNetUsers);
        }

        // GET: AspNetUsers/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aspNetUsers = await _context.AspNetUsers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return View(aspNetUsers);
        }

        // POST: AspNetUsers/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var aspNetUsers = await _context.AspNetUsers.FindAsync(id);
            _context.AspNetUsers.Remove(aspNetUsers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AspNetUsersExists(string id)
        {
            return _context.AspNetUsers.Any(e => e.Id == id);
        }
    }
}
