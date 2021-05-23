using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Museum.Data;
using Museum.Models;
using Museum.ViewModels;

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

        /// <summary>
        /// Returns Exhibits between selected years
        /// </summary>
        /// <param name="yearStart">Start Year</param>
        /// <param name="yearEnd">End Year</param>
        /// <returns>A list of exhibits between given range</returns>
        [HttpGet]
        [Route("filter/{yearStart & yearEnd}")]
        public async Task<ActionResult<IEnumerable<Exhibits>>> FilterExhibits(int yearStart, int yearEnd)
        {
            var query = _context.Exhibits.Where(e => e.Year >= yearStart && e.Year <= yearEnd);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Returns Exhibits by id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The searched exhibit</returns>
        // GET: api/Exhibits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExhibitsViewModel>> GetExhibits(int id)
        {
            var exhibits = await _context.Exhibits.FindAsync(id);

            var exhibitsViewModel = new ExhibitsViewModel
            {
                Name = exhibits.Name,
                Author = exhibits.Author,
                Year = exhibits.Year
            };

            if (exhibits == null)
            {
                return NotFound();
            }

            return exhibitsViewModel;
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
