/*
 * Description : Api Controller to work with tasksUser.js. 
 * Handle CRUD of UserTasks via Ajax form.
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
    public class UserTasksApiController : ControllerBase
    {
        private readonly ColocContext _context;

        public UserTasksApiController(ColocContext context)
        {
            _context = context;
        }

        // GET: api/UserTasksApi
        [HttpGet]
        public IEnumerable<UserTasks> GetUserTasks()
        {
            return _context.UserTasks;
        }

        // GET: api/UserTasksApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserTasks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTasks = await _context.UserTasks.FindAsync(id);

            if (userTasks == null)
            {
                return NotFound();
            }

            return Ok(userTasks);
        }

        // PUT: api/UserTasksApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTasks([FromRoute] int id, [FromBody] UserTasks userTasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userTasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(userTasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTasksExists(id))
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

        // POST: api/UserTasksApi
        [HttpPost]
        public async Task<IActionResult> PostUserTasks([FromBody] UserTasks userTasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserTasks.Add(userTasks);
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetUserTasks", new { id = userTasks.Id }, userTasks);
        }

        // DELETE: api/UserTasksApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserTasks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userTasks = await _context.UserTasks.FindAsync(id);
            if (userTasks == null)
            {
                return NotFound();
            }

            _context.UserTasks.Remove(userTasks);
            await _context.SaveChangesAsync();

            return Ok(userTasks);
        }

        private bool UserTasksExists(int id)
        {
            return _context.UserTasks.Any(e => e.Id == id);
        }
    }
}