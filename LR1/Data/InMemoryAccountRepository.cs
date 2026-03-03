using LR1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Data
{
    internal class InMemoryAccountRepository : IAccountRepository
    {
        private List<Account> Accounts = new List<Account>();

  
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        public List<Account> GetAccountClientId(Guid clientId)
        {
            return Accounts.Where(x => x.ClientId == clientId).ToList();
        }
    }
}
