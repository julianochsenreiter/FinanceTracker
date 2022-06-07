using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceTrackerLibrary.Models;

namespace FinanceTrackerService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BondsController : ControllerBase
    {
        private readonly financetrackerContext _context;

        public BondsController()
        {
            _context = Context.context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bonds>>> GetBonds()
        {
          if (_context.Bonds == null)
          {
              return NotFound();
          }
            return await _context.Bonds.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bonds>> GetBonds(int id)
        {
          if (_context.Bonds == null)
          {
              return NotFound();
          }
            var bonds = await _context.Bonds.FindAsync(id);

            if (bonds == null)
            {
                return NotFound();
            }

            return bonds;
        }

        [HttpPost]
        public async Task<ActionResult<Bonds>> PostBonds(Bonds bonds)
        {
          if (_context.Bonds == null)
          {
              return Problem("Entity set 'financetrackerContext.Bonds'  is null.");
          }
            _context.Bonds.Add(bonds);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BondsExists(bonds.Seid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBonds", new { id = bonds.Seid }, bonds);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBonds(int id)
        {
            if (_context.Bonds == null)
            {
                return NotFound();
            }
            var bonds = await _context.Bonds.FindAsync(id);
            if (bonds == null)
            {
                return NotFound();
            }

            _context.Bonds.Remove(bonds);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BondsExists(int id)
        {
            return (_context.Bonds?.Any(e => e.Seid == id)).GetValueOrDefault();
        }
    }
}
