using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintAPI.Models
{
    public class DataModels
    {
        public class CreateRepairModel
        {
            public int ID { get; set; }
            public int Tenant_ID { get; set; }
            public int Worker_ID { get; set; }
            public int Complex_ID { get; set; }
            public string Issue { get; set; }
            public string IssueDetails { get; set; }
            public string Status { get; set; }
            public bool ActiveFlag { get; set; }

        }

        public class CreateTenantModel
        {
            public int TenantID { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public bool ActiveFlag { get; set; }
        }
    }
}