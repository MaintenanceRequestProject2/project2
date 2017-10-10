using System;
using System.Collections.Generic;

namespace AdminUI.MainDb
{
    public partial class Users
    {
        public Users()
        {
            RepairsTenant = new HashSet<Repairs>();
            RepairsWorker = new HashSet<Repairs>();
        }

        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? ActiveFlag { get; set; }

        public ICollection<Repairs> RepairsTenant { get; set; }
        public ICollection<Repairs> RepairsWorker { get; set; }
    }
}
