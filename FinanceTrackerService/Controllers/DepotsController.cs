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
    public class DepotsController : ControllerBase
    {
        private readonly financetrackerContext _context;

        public DepotsController()
        {
            _context = Context.context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Depot>>> GetDepot()
        {
          if (_context.Depot == null)
          {
              return NotFound();
          }
            return await _context.Depot.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Depot>> GetDepot(int id)
        {
          if (_context.Depot == null)
          {
              return NotFound();
          }
            var depot = await _context.Depot.FindAsync(id);

            if (depot == null)
            {
                return NotFound();
            }

            return depot;
        }

        [HttpPost]
        public async Task<ActionResult<Depot>> PostDepot(Depot depot)
        {
          if (_context.Depot == null)
          {
              return Problem("Entity set 'financetrackerContext.Depot'  is null.");
          }
            _context.Depot.Add(depot);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DepotExists(depot.Did))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDepot", new { id = depot.Did }, depot);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepot(int id)
        {
            if (_context.Depot == null)
            {
                return NotFound();
            }
            var depot = await _context.Depot.FindAsync(id);
            if (depot == null)
            {
                return NotFound();
            }

            _context.Depot.Remove(depot);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepotExists(int id)
        {
            return (_context.Depot?.Any(e => e.Did == id)).GetValueOrDefault();
        }
    }
}
