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
    public class EnvironmentalsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public EnvironmentalsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Environmentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Environmental>>> GetEnvironment()
        {
            return await _context.Environment.ToListAsync();
        }

        // GET: api/Environmentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Environmental>> GetEnvironmental(Guid id)
        {
            var environmental = await _context.Environment.FindAsync(id);

            if (environmental == null)
            {
                return NotFound();
            }

            return environmental;
        }

        // PUT: api/Environmentals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEnvironmental(Guid id, Environmental environmental)
        {
            if (id != environmental.ID)
            {
                return BadRequest();
            }

            _context.Entry(environmental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentalExists(id))
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

        // POST: api/Environmentals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Environmental>> PostEnvironmental(Environmental environmental)
        {
            _context.Environment.Add(environmental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEnvironmental", new { id = environmental.ID }, environmental);
        }

        // DELETE: api/Environmentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEnvironmental(Guid id)
        {
            var environmental = await _context.Environment.FindAsync(id);
            if (environmental == null)
            {
                return NotFound();
            }

            _context.Environment.Remove(environmental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnvironmentalExists(Guid id)
        {
            return _context.Environment.Any(e => e.ID == id);
        }
    }
}
