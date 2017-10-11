using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminUI.DataLayer;
using Microsoft.Extensions.Configuration;
using DataLayer.Models;

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Workers")]
    public class WorkersController : Controller
    {
        //private readonly RegistrationDatabaseContext _context;
        private RegistrationDatabaseContext db = new RegistrationDatabaseContext();

        IConfiguration _configuration;

        public WorkersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Workers
        [HttpGet]
        public IEnumerable<Worker> GetWorkers()
        {
            String connectionString = _configuration.GetConnectionString("MainDB");


            Worker worker1 = new Worker(1, "John", "Branthony", "yes@yes.com", "jbran", "pw", "worker");    
            return new Worker[] { worker1 };
        }

        // GET: api/Workers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var workers = await db.Workers.SingleOrDefaultAsync(m => m.Id == id);

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

            db.Entry(workers).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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

            db.Workers.Add(workers);
            try
            {
                await db.SaveChangesAsync();
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

            var workers = await db.Workers.SingleOrDefaultAsync(m => m.Id == id);
            if (workers == null)
            {
                return NotFound();
            }

            db.Workers.Remove(workers);
            await db.SaveChangesAsync();

            return Ok(workers);
        }

        private bool WorkersExists(int id)
        {
            return db.Workers.Any(e => e.Id == id);
        }
    }
}