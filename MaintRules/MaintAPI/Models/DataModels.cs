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
            
        }
    }
}