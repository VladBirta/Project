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
    public class FuneralsController : ControllerBase
    {
        private readonly ProjectContext _context;

        public FuneralsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/Funerals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Funerals>>> GetFunerals()
        {
            return await _context.Funerals.ToListAsync();
        }

        // GET: api/Funerals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funerals>> GetFunerals(int id)
        {
            var funerals = await _context.Funerals.FindAsync(id);

            if (funerals == null)
            {
                return NotFound();
            }

            return funerals;
        }

        // PUT: api/Funerals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFunerals(int id, Funerals funerals)
        {
            if (id != funerals.FuneralsId)
            {
                return BadRequest();
            }

            _context.Entry(funerals).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuneralsExists(id))
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

        // POST: api/Funerals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Funerals>> PostFunerals(Funerals funerals)
        {
            _context.Funerals.Add(funerals);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFunerals", new { id = funerals.FuneralsId }, funerals);
        }

        // DELETE: api/Funerals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFunerals(int id)
        {
            var funerals = await _context.Funerals.FindAsync(id);
            if (funerals == null)
            {
                return NotFound();
            }

            _context.Funerals.Remove(funerals);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuneralsExists(int id)
        {
            return _context.Funerals.Any(e => e.FuneralsId == id);
        }
    }
}
