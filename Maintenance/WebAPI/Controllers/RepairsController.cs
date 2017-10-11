using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using UserUI.Models;
using AdminUI.DataLayer;

namespace UserUI.Controllers
{
    [Produces("application/json")]
    [Route("api/Repairs")]
    public class RepairsController : Controller
    {

        // Db Context
        private RegistrationDatabaseContext db = new RegistrationDatabaseContext();

        IConfiguration _configuration;

        public RepairsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/Repairs
        [HttpGet]
        public IEnumerable<Repair> Get()
        {
            String connectionString = _configuration.GetConnectionString("MainDB");

            Repair repair1 = new Repair(1, 1, 2850, "Broken Washer", "", "Open");
            Repair repair2 = new Repair(1, 1, 2850, "Ceiling Fan", "It's Dusty", "Open");

            return new Repair[] { repair1, repair2 };
        }

        // GET AND DISPLAY
        [Route("GetRepairJobs")]
        public IQueryable<Repairs> GetRepairJobs()
        {
            return db.Repairs.AsQueryable();
        }


        // GET: api/Repairs/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var repairGuy = db.Repairs.FirstOrDefault((p) => p.Id == id);
            if (repairGuy == null)
            {
                return NotFound();
            }

            return new ObjectResult(repairGuy);
        }
        
        // POST: api/Repairs
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Repairs/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
