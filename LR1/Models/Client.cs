using LR1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Models
{
    internal class Client : User
    {
        public bool IsApproved { get; private set; }
        public Client(string name, string password) : base(name, password)
        {
            Role = Role.Client;
            IsApproved = false;
        }
        public void Approved()
        {
            IsApproved = true;
        }

    }
}
