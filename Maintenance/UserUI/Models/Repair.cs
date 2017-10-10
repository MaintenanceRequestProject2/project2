using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserUI.Models
{
    public class Repair
    {
        private int Tenant_ID;
        private int Worker_ID;
        private int Complex_ID;
        private String Issue;
        private String IssueDetails;
        private String Status;

        public Repair(int tenant_ID, int worker_ID, int complex_ID, string issue, string issueDetails, string status)
        {
            this.Tenant_ID = tenant_ID;
            this.Worker_ID = worker_ID;
            this.Complex_ID = complex_ID;
            this.Issue = issue;
            this.IssueDetails = issueDetails;
            this.Status = status;
        }

        public int Tenant_ID1 { get => Tenant_ID; set => Tenant_ID = value; }
        public int Worker_ID1 { get => Worker_ID; set => Worker_ID = value; }
        public int Complex_ID1 { get => Complex_ID; set => Complex_ID = value; }
        public string Issue1 { get => Issue; set => Issue = value; }
        public string IssueDetails1 { get => IssueDetails; set => IssueDetails = value; }
        public string Status1 { get => Status; set => Status = value; }


    }
}
