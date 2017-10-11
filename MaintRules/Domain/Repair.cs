using System;
using System.Collections.Generic;

namespace MaintRules.Domain
{
    public class Repair
    {
        public int ID { get; set; }
        public int Tenant_ID { get; set; }
        public int Worker_ID { get; set; }
        public int Complex_ID { get; set; }
        public string Issue { get; set; }
        public string IssueDetails { get; set; }
        public string Status { get; set; }
        public bool ActiveFlag { get; set; }


        public Repair(int Tenant_ID, string Issue, string IssueDetails)
        {
            this.Tenant_ID = Tenant_ID;
            this.Issue = Issue;
            this.IssueDetails = IssueDetails;
            Status = "Open";
            ActiveFlag = true;
        }

        public Repair(int iD, int tenant_ID, int worker_ID, int complex_ID, string issue, string issueDetails, string status, bool activeFlag)
        {
            ID = iD;
            Tenant_ID = tenant_ID;
            Worker_ID = worker_ID;
            Complex_ID = complex_ID;
            Issue = issue;
            IssueDetails = issueDetails;
            Status = status;
            ActiveFlag = activeFlag;
        }

        public void CompleteRepair()
        {
            Status = "Resolved";
            ActiveFlag = false;
        }
    }
}
