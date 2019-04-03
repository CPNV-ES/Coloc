using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Coloc.Models;

namespace Coloc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogbookssApiController : ControllerBase
    {
        private readonly ColocContext _context;

        public LogbookssApiController(ColocContext context)
        {
            _context = context;
        }

        // GET: api/LogbookssApi
        [HttpGet]
        public IEnumerable<Logbooks> GetLogbooks()
        {
            return _context.Logbooks;
        }

        // GET: api/LogbookssApi/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogbooks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Logbooks = await _context.Logbooks.FindAsync(id);

            if (Logbooks == null)
            {
                return NotFound();
            }

            return Ok(Logbooks);
        }

        // PUT: api/LogbookssApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogbooks([FromRoute] int id, [FromBody] Logbooks Logbooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Logbooks.Id)
            {
                return BadRequest();
            }

            _context.Entry(Logbooks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogbooksExists(id))
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

        // POST: api/LogbookssApi
        [HttpPost]
        public async Task<IActionResult> PostLogbooks([FromBody] Logbooks Logbooks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Logbooks.Add(Logbooks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogbooks", new { id = Logbooks.Id }, Logbooks);
        }

        // DELETE: api/LogbookssApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogbooks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Logbooks = await _context.Logbooks.FindAsync(id);
            if (Logbooks == null)
            {
                return NotFound();
            }

            _context.Logbooks.Remove(Logbooks);
            await _context.SaveChangesAsync();

            return Ok(Logbooks);
        }

        private bool LogbooksExists(int id)
        {
            return _context.Logbooks.Any(e => e.Id == id);
        }
    }
}