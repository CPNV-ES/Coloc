using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Coloc.Models;

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
        public async Task<IActionResult> Create([Bind("Id,TaskId,UserId,BeginTask,EndTask,FinishTask,State")] UserTasks userTasks)
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
            ViewData["TaskId"] = new SelectList(_context.Tasks.OrderBy(r => r.Todo), "Id", "Description", userTasks.TaskId);

            //  Change the task of a user. List in a format: Todo - Task
            ViewData["TaskId"] = from u in _context.Tasks.OrderBy(r => r.Title).OrderBy(r => r.Todo)
                                  select new SelectListItem
                                  {
                                      Value = u.Id.ToString(),
                                      Text = u.Todo.Title + " - " + u.Title
                                  };


            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTasks.UserId);
            return View(userTasks);
        }

        // POST: UserTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskId,UserId,BeginTask,EndTask,FinishTask,State")] UserTasks userTasks)
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
                return RedirectToAction(nameof(Index));
            }
            ViewData["TaskId"] = new SelectList(_context.Tasks, "Id", "Description", userTasks.TaskId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", userTasks.UserId);
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
            return RedirectToAction(nameof(Index));
        }

        private bool UserTasksExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}
