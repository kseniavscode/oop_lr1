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
        public void CloseAccount(Guid clientId, Guid accountId)
        {
            accountRepository.GetAccountClientId(clientId).Remove(accountRepository.GetAccountById(accountId));
        }
        public List<Account> GetMyAccounts(Guid clientId)
        {
            return accountRepository.GetAccountClientId(clientId);
        }


        public string TransferToTheAccount(Guid clientId, Guid accountId, decimal count)
        {
            var acc = accountRepository.GetAccountById(accountId);
            if (acc.ClientId == clientId)
            {
                try
                {
                    acc.Deposit(count);
                }
                catch(Exception e) 
                {
                    return $"{e}";
                }
            }
            return "Успешное пополнение!";
        }

        public string WithdrawFromAccount(Guid clientId, Guid accountId, decimal count)
        {

            var acc = accountRepository.GetAccountById(accountId);
            if (acc.ClientId == clientId)
            {
                try
                {
                    acc.Withdraw(count);
                }
                catch (Exception e)
                {
                    return $"{e}";
                }
                
            }
            return "Успешное снятие!";
        }
    }
}
