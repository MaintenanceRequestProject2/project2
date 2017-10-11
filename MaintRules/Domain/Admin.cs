using System;
using System.Collections.Generic;

namespace MaintRules.Domain
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Admin(int adminID, string first, string last, string email, int phone, string password, string role)
        {
            AdminID = adminID;
            First = first;
            Last = last;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
        }

        public Repair AssignToOther(Repair r, Worker w)
        {
            r.Worker_ID = w.WorkerID;
            return r;
        }

        public Repair CloseRepair(Repair r)
        {
            r.Status = "Closed";
            r.ActiveFlag = false;
            return r;
        }

        public Repair ReopenRepair(Repair r)
        {
            r.Status = "Reopened";
            r.ActiveFlag = true;
            return r;
        }


        public Repair CreateRepair(Tenant t, string issue, string issuedetails)
        {
            var res = new Repair(t.TenantID, issue, issuedetails);

            if (t.ActiveFlag)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public Tenant AddTenant(int tenantID, string first, string last, string email, int phone, string password, string role) 
        {
            var res = new Tenant(tenantID, first, last, email, phone, password, role, true);
            return res;
        }

        public Tenant DeactivateTenant(Tenant t) {
            t.ActiveFlag = false;
            return t;
        }

        public Tenant ReactivateTenant(Tenant t) 
        {
            t.ActiveFlag = true;
            return t;
        }

        public Worker AddWorker(int workerID, string first, string last, string email, int phone, string password, string role)
        {
            var res = new Worker(workerID, first, last, email, phone, password, role);
            return res;
        }

        public static void Main(){
            
        }

    }
}

