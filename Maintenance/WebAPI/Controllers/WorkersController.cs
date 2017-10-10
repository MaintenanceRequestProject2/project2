using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminUI.DataLayer;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Workers")]
    public class WorkersController : Controller
    {
        private readonly RegistrationDatabaseContext _context;

        public WorkersController(RegistrationDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Workers
        [HttpGet]
        public IEnumerable<Workers> GetWorkers()
        {
            return _context.Workers;
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workers = await _context.Workers.SingleOrDefaultAsync(m => m.Id == id);

            if (workers == null)
            {
                return NotFound();
            }

            return Ok(workers);
        }

        // PUT: api/Workers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkers([FromRoute] int id, [FromBody] Workers workers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workers.Id)
            {
                return BadRequest();
            }

            _context.Entry(workers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkersExists(id))
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

        // POST: api/Workers
        [HttpPost]
        public async Task<IActionResult> PostWorkers([FromBody] Workers workers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Workers.Add(workers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (WorkersExists(workers.Id))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetWorkers", new { id = workers.Id }, workers);
        }

        // DELETE: api/Workers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workers = await _context.Workers.SingleOrDefaultAsync(m => m.Id == id);
            if (workers == null)
            {
                return NotFound();
            }

            _context.Workers.Remove(workers);
            await _context.SaveChangesAsync();

            return Ok(workers);
        }

        private bool WorkersExists(int id)
        {
            return _context.Workers.Any(e => e.Id == id);
        }
    }
}