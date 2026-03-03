using LR1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Data
{
    internal class InMemoryUserRepositoryn: IUserRepository
    {
        private List<User> Users = new List<User>(); 

        public InMemoryUserRepositoryn()
        {
            Users.Add(new Admin("admin", "1234"));
        }
        public void AddUser(User user)
        {
            Users.Add(user);
        }
        public User GetUserByNameAndPassword(string name, string password)
        {
            return Users.FirstOrDefault(x => x.Name == name && x.Password == password);
        }
        public bool UserExist(string name)
        {
            return Users.Any(x => x.Name == name);
        }
    }
}
