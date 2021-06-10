using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public SportsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Sports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sports>>> GetSports()
        {
            return await _context.Sports.ToListAsync();
        }

        // GET: api/Sports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sports>> GetSports(int id)
        {
            var sports = await _context.Sports.FindAsync(id);

            if (sports == null)
            {
                return NotFound();
            }

            return sports;
        }

        // PUT: api/Sports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSports(int id, Sports sports)
        {
            if (id != sports.SportsId)
            {
                return BadRequest();
            }

            _context.Entry(sports).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SportsExists(id))
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

        // POST: api/Sports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sports>> PostSports(Sports sports)
        {
            _context.Sports.Add(sports);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSports", new { id = sports.SportsId }, sports);
        }

        // DELETE: api/Sports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSports(int id)
        {
            var sports = await _context.Sports.FindAsync(id);
            if (sports == null)
            {
                return NotFound();
            }

            _context.Sports.Remove(sports);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SportsExists(int id)
        {
            return _context.Sports.Any(e => e.SportsId == id);
        }
    }
}
