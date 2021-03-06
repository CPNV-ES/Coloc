﻿
/*
 * Description : API controller to create new Tasks via Ajax form.
 * 
 * Author : Julien Richoz / SI-T2a / CPNV-ES
 * Date : 31.03.2019
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coloc.Models;
using Microsoft.AspNetCore.Authorization;

namespace Coloc.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksApiController : ControllerBase
    {
        private readonly ColocContext _context;

        public TasksApiController(ColocContext context)
        {
            _context = context;
        }

        // GET: api/TasksApi
        [HttpGet]
        public IEnumerable<Tasks> GetTasks()
        {
            return _context.Tasks;
        }

        // GET: api/TasksApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return Ok(tasks);
        }

        // PUT: api/TasksApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasks([FromRoute] int id, [FromBody] Tasks tasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TasksApi
        [HttpPost]
        public async Task<IActionResult> PostTasks([FromBody] Tasks tasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = tasks.Id }, tasks);
        }

        // DELETE: api/TasksApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return Ok(tasks);
        }

        private bool TasksExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}