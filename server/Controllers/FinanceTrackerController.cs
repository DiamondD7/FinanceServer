using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Model;

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceTrackerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FinanceTrackerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/FinanceTracker
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FinanceTracker>>> GetFinanceTracker()
        {
            return await _context.FinanceTracker.ToListAsync();
        }

        // GET: api/FinanceTracker/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FinanceTracker>> GetFinanceTracker(int id)
        {
            var financeTracker = await _context.FinanceTracker.FindAsync(id);

            if (financeTracker == null)
            {
                return NotFound();
            }

            return financeTracker;
        }

        // PUT: api/FinanceTracker/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFinanceTracker(int id, FinanceTracker financeTracker)
        {
            if (id != financeTracker.Id)
            {
                return BadRequest();
            }

            _context.Entry(financeTracker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FinanceTrackerExists(id))
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

        // POST: api/FinanceTracker
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FinanceTracker>> PostFinanceTracker(FinanceTracker financeTracker)
        {
            _context.FinanceTracker.Add(financeTracker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFinanceTracker", new { id = financeTracker.Id }, financeTracker);
        }

        // DELETE: api/FinanceTracker/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFinanceTracker(int id)
        {
            var financeTracker = await _context.FinanceTracker.FindAsync(id);
            if (financeTracker == null)
            {
                return NotFound();
            }

            _context.FinanceTracker.Remove(financeTracker);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: /api/FinanceTracker/
        [HttpDelete("deleteAll")]
        public async Task<IActionResult> DeleteAllFinanceTracker()
        {
            var todelete = _context.FinanceTracker.Select(a => new FinanceTracker { Id = a.Id }).ToList();
            _context.FinanceTracker.RemoveRange(todelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool FinanceTrackerExists(int id)
        {
            return _context.FinanceTracker.Any(e => e.Id == id);
        }
    }
}
