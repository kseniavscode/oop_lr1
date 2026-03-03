using System;
using System.Collections.Generic;
using System.Text;
using LR1.Enums;

namespace LR1.Models
{
    internal class Manager : User
    {
        private Guid BankId { get; set; }
        public Manager(string name, string password, Guid bankId) : base(name, password) 
        {
            Role = Role.Manager;
            BankId = bankId;
        }
    }
}
