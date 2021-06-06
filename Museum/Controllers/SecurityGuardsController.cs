using Microsoft.AspNetCore.Mvc;
using Museum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Museum.Models;

namespace Museum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityGuardsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SecurityGuardsController(ApplicationDbContext context )
        {
            _context = context;
        }

        // GET: api/SecurityGuard
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SecurityGuard>>> GetSecurityGuard()
        {
            return await _context.SecurityGuards.ToListAsync();
        }

        // GET: api/SecurityGuard/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SecurityGuard>> GetSecurityGuard(int id)
        {
            var book = await _context.SecurityGuards.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        // PUT: api/SecurityGuard/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecurityGuard(int id, SecurityGuard securityGuard)
        {
            if (id != securityGuard.ID)
            {
                return BadRequest();
            }

            _context.Entry(securityGuard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecurityGuardExists(id))
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

        // POST: api/SecurityGuard
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SecurityGuard>> PostSecurityGuard(SecurityGuard securityGuard)
        {
            _context.SecurityGuards.Add(securityGuard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBook", new { id = securityGuard.ID }, securityGuard);
        }

        // DELETE: api/SecurityGuard/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecurityGuard(int id)
        {
            var securityGuard = await _context.SecurityGuards.FindAsync(id);
            if (securityGuard == null)
            {
                return NotFound();
            }

            _context.SecurityGuards.Remove(securityGuard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecurityGuardExists(int id)
        {
            return _context.SecurityGuards.Any(e => e.ID == id);
        }
    }
}
