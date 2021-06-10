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
    public class PoliticsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public PoliticsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Politics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Politics>>> GetPolitics()
        {
            return await _context.Politics.ToListAsync();
        }

        // GET: api/Politics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Politics>> GetPolitics(int id)
        {
            var politics = await _context.Politics.FindAsync(id);

            if (politics == null)
            {
                return NotFound();
            }

            return politics;
        }

        // PUT: api/Politics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitics(int id, Politics politics)
        {
            if (id != politics.PoliticsId)
            {
                return BadRequest();
            }

            _context.Entry(politics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoliticsExists(id))
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

        // POST: api/Politics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Politics>> PostPolitics(Politics politics)
        {
            _context.Politics.Add(politics);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPolitics", new { id = politics.PoliticsId }, politics);
        }

        // DELETE: api/Politics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitics(int id)
        {
            var politics = await _context.Politics.FindAsync(id);
            if (politics == null)
            {
                return NotFound();
            }

            _context.Politics.Remove(politics);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoliticsExists(int id)
        {
            return _context.Politics.Any(e => e.PoliticsId == id);
        }
    }
}
