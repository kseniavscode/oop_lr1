using LR1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using LR1.Data;

namespace LR1.Services
{
    internal class Service
    {
        private readonly IUserRepository UserRepozitory;

        public Service(IUserRepository userRepozitory)
        {
            UserRepozitory = userRepozitory;
        }
        public Client Registration(string name, string password)
        {
            if (!UserRepozitory.UserExist(name))
            {
                var newClient = new Client(name, password);
                UserRepozitory.AddUser(newClient);
                return newClient;
            }
            return null;
        }
        public User Login(string name, string password)
        {
            return UserRepozitory.GetUserByNameAndPassword(name, password);
        }
    }
}
