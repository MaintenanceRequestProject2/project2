using System;
using System.Collections.Generic;

namespace AdminUI.DataLayer
{
    public partial class Tenants
    {
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool? ActiveFlag { get; set; }
    }
}
