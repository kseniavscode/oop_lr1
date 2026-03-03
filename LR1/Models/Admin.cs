using System;
using System.Collections.Generic;
using System.Text;
using LR1.Enums;

namespace LR1.Models
{
    internal class Admin : User
    {
        public Admin(string name, string password) : base(name, password)
        {
            Role = Role.Admin;
        }
    }
}
