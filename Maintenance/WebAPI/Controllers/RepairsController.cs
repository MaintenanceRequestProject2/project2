﻿using System;
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

        // GET: api/Repairs/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
