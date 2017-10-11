using MaintRules.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaintAPI.Models
{
    public class RepairModel
    {

        public Repair R { get; set; }
        public RepairModel(Repair rm)
        {
            R = rm;
        }

    }
}
