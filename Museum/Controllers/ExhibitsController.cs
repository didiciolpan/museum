using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum.Data;
using Museum.Models;

namespace Museum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExhibitsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExhibitsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Exhibits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exhibits>>> GetExhibits()
        {
            return await _context.Exhibits.ToListAsync();
        }

        // GET: api/Exhibits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exhibits>> GetExhibits(int id)
        {
            var exhibits = await _context.Exhibits.FindAsync(id);

            if (exhibits == null)
            {
                return NotFound();
            }

            return exhibits;
        }

        // PUT: api/Exhibits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExhibits(int id, Exhibits exhibits)
        {
            if (id != exhibits.Id)
            {
                return BadRequest();
            }

            _context.Entry(exhibits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExhibitsExists(id))
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

        // POST: api/Exhibits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exhibits>> PostExhibits(Exhibits exhibits)
        {
            _context.Exhibits.Add(exhibits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExhibits", new { id = exhibits.Id }, exhibits);
        }

        // DELETE: api/Exhibits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExhibits(int id)
        {
            var exhibits = await _context.Exhibits.FindAsync(id);
            if (exhibits == null)
            {
                return NotFound();
            }

            _context.Exhibits.Remove(exhibits);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExhibitsExists(int id)
        {
            return _context.Exhibits.Any(e => e.Id == id);
        }
    }
}
