using LR1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Models
{
    internal class Client : User
    {
        private bool IsApproved { get; set; } = false;
        private List<Guid> AccountsId { get; set; }
        public Client(string name, string password) : base(name, password)
        {
            Role = Role.Client;
            AccountsId = new List<Guid>();
        }

    }
}
