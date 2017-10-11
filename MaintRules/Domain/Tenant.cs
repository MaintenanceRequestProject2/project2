using System;
using System.Collections.Generic;

namespace MaintRules.Domain
{
    public class Tenant
    {
            public int TenantID { get; set; }
            public string First { get; set; }
            public string Last { get; set; }
            public string Email { get; set; }
            public int Phone { get; set; }
            public string Password { get; set; }
            public string Role { get; set; }
            public bool ActiveFlag { get; set; }

        public Tenant(int tenantID, string email)
        {
            TenantID = tenantID;
            Email = email;
        }
    
        public Tenant(int TenantID, string First, String Last, string Email)
        {
            this.TenantID = TenantID;
            this.First = First;
            this.Last = Last;
            this.Email = Email;
            ActiveFlag = true;
        }

        public Tenant(int tenantID, string first, string last, string email, int phone, string password, string role, bool activeFlag)
        {
            TenantID = tenantID;
            First = first;
            Last = last;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
            ActiveFlag = activeFlag;
        }

        public Repair CreateRepair(string issue, string issuedetails) 
        {
            var res = new Repair(TenantID, issue, issuedetails);

            if (ActiveFlag) 
            {
                return res;
            } else {
                return null;
            }
        }
    }
}
