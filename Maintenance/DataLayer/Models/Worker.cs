using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Worker
    {
        private int ID;
        private String First;
        private String Last;
        private String Email;
        private String Phone;
        private String Password;
        private String Role;

        public Worker(int iD, string first, string last, string email, string phone, string password, string role)
        {
            ID1 = iD;
            First1 = first;
            Last1 = last;
            Email1 = email;
            Phone1 = phone;
            Password1 = password;
            Role1 = role;
        }

        public int ID1 { get => ID; set => ID = value; }
        public string First1 { get => First; set => First = value; }
        public string Last1 { get => Last; set => Last = value; }
        public string Email1 { get => Email; set => Email = value; }
        public string Phone1 { get => Phone; set => Phone = value; }
        public string Password1 { get => Password; set => Password = value; }
        public string Role1 { get => Role; set => Role = value; }
    }
}
