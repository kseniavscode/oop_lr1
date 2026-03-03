using LR1.Data;
using LR1.Models;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace LR1.Services
{
    internal class ClientService
    {
        private readonly IAccountRepository accountRepository;

        public ClientService(IAccountRepository account)
        {
            accountRepository = account;
        }
        public Account OpenAccount(Guid clientId)
        {
            var new_account = new Account(clientId);
            accountRepository.AddAccount(new_account);
            return new_account;
        }
        public void CloseAccount(Guid clientId, Account account)
        {
            accountRepository.GetAccountClientId(clientId).Remove(account);
        }
        public List<Account> GetMyAccounts(Guid clientId)
        {
            return accountRepository.GetAccountClientId(clientId);
        }
    }
}
