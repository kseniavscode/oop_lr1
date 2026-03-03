using System;
using System.Collections.Generic;
using System.Text;
using LR1.Enums;

namespace LR1.Models
{
    internal abstract class User
    {
        protected Guid Id { get; set; }
        private string Name { get; set; }
        private string Password { get; set; }
        protected Role Role { get; set; }

        protected User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }
    }

    
}
