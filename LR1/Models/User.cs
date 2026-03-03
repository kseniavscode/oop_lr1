using System;
using System.Collections.Generic;
using System.Text;
using LR1.Enums;

namespace LR1.Models
{
    internal abstract class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Password { get; private set; }
        public Role Role { get; set; }

        protected User(string name, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
        }
    }

    
}
