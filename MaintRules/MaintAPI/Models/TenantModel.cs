using MaintRules.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintAPI.Models
{
    public class TenantModel
    {

        //for binding
        public int TenantId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //for logical operations
        public Tenant TenantLogic { get; set; }

        public TenantModel(Tenant t)
        {
            TenantLogic = t;
            TenantId = t.TenantID;
            Email = t.Email;
        }
        public TenantModel() { }

        public void Transfer()
        {
            TenantLogic = new Tenant(TenantId, Email);
        }

        public override string ToString()
        {
            return "Email: " + Email + "\n TenantId: " + TenantId;
        }
    }
}