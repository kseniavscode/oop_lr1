using LR1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Data
{
    internal interface IAccountRepository
    {
        void AddAccount(Account account);
        List<Account> GetAccountClientId(Guid clientId);
        Account GetAccountById(Guid id);
    }
}
