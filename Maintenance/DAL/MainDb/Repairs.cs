using System;
using System.Collections.Generic;

namespace AdminUI.MainDb
{
    public partial class Repairs
    {
        public int Id { get; set; }
        public int TenantId { get; set; }
        public int WorkerId { get; set; }
        public int ComplexId { get; set; }
        public string Issue { get; set; }
        public string IssueDetails { get; set; }
        public string Status { get; set; }
        public bool? ActiveFlag { get; set; }

        public Users Tenant { get; set; }
        public Users Worker { get; set; }
    }
}
