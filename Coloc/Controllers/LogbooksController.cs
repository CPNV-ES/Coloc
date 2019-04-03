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
    public class LogbookssController : Controller
    {
        private readonly ColocContext _context;

        public LogbookssController(ColocContext context)
        {
            _context = context;
        }

        // GET: Logbookss
        public async Task<IActionResult> Index()
        {
            var colocContext = _context.Logbooks.Include(l => l.AspNetUser);
            return View(await colocContext.ToListAsync());
        }

        // GET: Logbookss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Logbooks = await _context.Logbooks
                .Include(l => l.AspNetUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Logbooks == null)
            {
                return NotFound();
            }

            return View(Logbooks);
        }

        // GET: Logbookss/Create
        public IActionResult Create()
        {
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        // POST: Logbookss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AspNetUserId,Moment,Eventdescription")] Logbooks Logbooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Logbooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", Logbooks.AspNetUserId);
            return View(Logbooks);
        }

        // POST: Logbookss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateLogTask([Bind("Id,AspNetUserId,Moment,Eventdescription")] Logbooks Logbooks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Logbooks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", Logbooks.AspNetUserId);
            return View(Logbooks);
        }

        // GET: Logbookss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Logbooks = await _context.Logbooks.FindAsync(id);
            if (Logbooks == null)
            {
                return NotFound();
            }
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", Logbooks.AspNetUserId);
            return View(Logbooks);
        }

        // POST: Logbookss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AspNetUserId,Moment,Eventdescription")] Logbooks Logbooks)
        {
            if (id != Logbooks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Logbooks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LogbooksExists(Logbooks.Id))
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
            ViewData["AspNetUserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", Logbooks.AspNetUserId);
            return View(Logbooks);
        }

        // GET: Logbookss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Logbooks = await _context.Logbooks
                .Include(l => l.AspNetUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Logbooks == null)
            {
                return NotFound();
            }

            return View(Logbooks);
        }

        // POST: Logbookss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Logbooks = await _context.Logbooks.FindAsync(id);
            _context.Logbooks.Remove(Logbooks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogbooksExists(int id)
        {
            return _context.Logbooks.Any(e => e.Id == id);
        }
    }
}
