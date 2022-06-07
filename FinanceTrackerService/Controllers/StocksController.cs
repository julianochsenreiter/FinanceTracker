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
    public class StocksController : ControllerBase
    {
        private readonly financetrackerContext _context;

        public StocksController()
        {
            _context = Context.context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stocks>>> GetStocks()
        {
          if (_context.Stocks == null)
          {
              return NotFound();
          }
            return await _context.Stocks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Stocks>> GetStocks(int id)
        {
          if (_context.Stocks == null)
          {
              return NotFound();
          }
            var stocks = await _context.Stocks.FindAsync(id);

            if (stocks == null)
            {
                return NotFound();
            }

            return stocks;
        }

        [HttpPost]
        public async Task<ActionResult<Stocks>> PostStocks(Stocks stocks)
        {
          if (_context.Stocks == null)
          {
              return Problem("Entity set 'financetrackerContext.Stocks'  is null.");
          }
            _context.Stocks.Add(stocks);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StocksExists(stocks.Seid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStocks", new { id = stocks.Seid }, stocks);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStocks(int id)
        {
            if (_context.Stocks == null)
            {
                return NotFound();
            }
            var stocks = await _context.Stocks.FindAsync(id);
            if (stocks == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stocks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StocksExists(int id)
        {
            return (_context.Stocks?.Any(e => e.Seid == id)).GetValueOrDefault();
        }
    }
}
