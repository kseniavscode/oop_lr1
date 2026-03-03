using LR1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Data
{
    internal interface IUserRepository
    {
        void AddUser(User user);
        User GetUserByNameAndPassword(string name, string password);
        bool UserExist(string name);
    }
}
