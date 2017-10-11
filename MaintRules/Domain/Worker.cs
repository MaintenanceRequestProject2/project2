using System;
using System.Collections.Generic;

namespace MaintRules.Domain
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool ActiveFlag { get; set; }

        public Worker(int workerID, string first, string last, string email, int phone, string password, string role, bool activeFlag)
        {
            WorkerID = workerID;
            First = first;
            Last = last;
            Email = email;
            Phone = phone;
            Password = password;
            Role = role;
            ActiveFlag = activeFlag;
        }

        public Repair AssignToSelf(Repair r)
        {
            r.Worker_ID = WorkerID;
            return r;
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

        public Repair ChangeDetails(Repair r, string newdetail) 
        {
            r.IssueDetails = newdetail;
            return r;
        }

        public Repair CreateRepair(Tenant t, string issue, string issuedetails) 
        {
            var res = new Repair(t.TenantID, issue, issuedetails);

            if (ActiveFlag) 
            {
                return res;
            } else {
                return null;
            }
        }
    }
}
