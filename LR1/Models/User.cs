using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Models
{
    internal abstract class User
    {
        private Guid Id { get; set; }
        private string Name { get; set; }
        private string Password { get; set; }
        private Role Role { get; set; }

        public User(string name, string password, Role role)
        {
            Id = Guid.NewGuid();
            Name = name;
            Password = password;
            Role = role;
        }
    }

    enum Role
    {
        Client,
        Manager,
        Admin
    }
}
