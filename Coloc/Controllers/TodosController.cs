﻿/*
 * Description : Controller to handle Todo
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
using Microsoft.AspNetCore.Authorization;

namespace Coloc.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TodosController : Controller
    {
        private readonly ColocContext _context;

        public TodosController(ColocContext context)
        {
            _context = context;
        }

        // GET: Todos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Todos.Include(t => t.Tasks).ToListAsync());
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todos = await _context.Todos
                .Include(r => r.Tasks)
                .FirstOrDefaultAsync(m => m.Id == id);

            

            if (todos == null)
            {
                return NotFound();
            }

            return View(todos);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] Todos todos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todos);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todos = await _context.Todos.FindAsync(id);
            if (todos == null)
            {
                return NotFound();
            }
            return View(todos);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] Todos todos)
        {
            if (id != todos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodosExists(todos.Id))
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
            return View(todos);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todos = await _context.Todos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todos == null)
            {
                return NotFound();
            }

            return View(todos);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todos = await _context.Todos.FindAsync(id);
            _context.Todos.Remove(todos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodosExists(int id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}
