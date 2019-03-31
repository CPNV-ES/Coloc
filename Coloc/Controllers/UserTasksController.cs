/*
 * Description : User Tasks Controller.
 * Handles lots of view redirection and ViewData
 * 
 * Author : Julien Richoz / SI-T2a / CPNV-ES
 * Date : 31.03.2019
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coloc.Models;
using Microsoft.AspNetCore.Routing;

namespace Coloc.Controllers
{
    public class UserTasksController : Controller
    {
        private readonly ColocContext _context;

        public UserTasksController(ColocContext context)
        {
            _context = context;
        }

        // GET: UserTasks
        public async Task<IActionResult> Index()
        {
            var colocContext = _context.UserTasks.Include(u => u.Task).Include(u => u.User);
            return View(await colocContext.ToListAsync());
        }

        // GET: UserTasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTasks = await _context.UserTasks
                .Include(u => u.Task)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTasks == null)
            {
                return NotFound();
            }
            ViewData["Task"] = _context.Tasks.Where(r => r.Id == userTasks.TaskId);
            return View(userTasks);
        }

        // GET: UserTasks/Create
        public IActionResult Create()
        {
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Description");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: UserTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskId,UserId,BeginTask,EndTask,State")] UserTasks userTasks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userTasks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Description", userTasks.TaskId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTasks.UserId);
            return View(userTasks);
        }

        // GET: UserTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTasks = await _context.UserTasks.FindAsync(id);
            if (userTasks == null)
            {
                return NotFound();
            }
            //  Change the task of a user. List in a format: Todo - Task
            ViewData["TaskId"] = from u in _context.Tasks.OrderBy(r => r.Title).OrderBy(r => r.Todo)
                                  select new SelectListItem
                                  {
                                      Value = u.Id.ToString(),
                                      Text = u.Todo.Title + " - " + u.Title
                                  };
           ViewData["Task"] = _context.Tasks.Where(r => r.Id == userTasks.TaskId).FirstOrDefault();

            // Show the userName instead of ID for better comprehension, in usertask edit
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "UserName", userTasks.User);

            ViewData["State"] = from s in _context.UserTasks.OrderBy(r => r.State).Select(r => r.State).Distinct().ToList()
                                select new SelectListItem
                                {
                                    Value = s.ToString(),
                                    Text = s.ToString()
                                };

            return View(userTasks);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskId,UserId,BeginTask,EndTask,State")] UserTasks userTasks)
        {
            if (id != userTasks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userTasks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserTasksExists(userTasks.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redirect the user to the details vue of the user
                if (id == userTasks.Id)
                {
                    return RedirectToAction("Details", new RouteValueDictionary(
                        new { controller = "AspNetUsers", action = "Details", Id = userTasks.UserId }));
                }
                return RedirectToAction(nameof(Index));
            }


            // Add to the view usefull data informations
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Description", userTasks.TaskId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTasks.UserId);
            ViewData["State"] = new SelectList(_context.UserTasks, "Id", "State", userTasks.State);

            return View(userTasks);
        }

        // GET: UserTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userTasks = await _context.UserTasks
                .Include(u => u.Task)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (userTasks == null)
            {
                return NotFound();
            }

             return View(userTasks);
        }

        // POST: UserTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userTasks = await _context.UserTasks.FindAsync(id);
            _context.UserTasks.Remove(userTasks);
            await _context.SaveChangesAsync();

            // Return to the list of users view
            //return RedirectToAction("Index", "AspNetUsers");
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "AspNetUsers", action = "Details", Id = userTasks.UserId }));
        }

        private bool UserTasksExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
