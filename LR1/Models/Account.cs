using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Models
{
    internal class Account
    {
        public Guid Id {  get; private set; }
        public Guid ClientId { get; private set; }
        public decimal Balance { get; private set; }

        public Account(Guid clientId)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            Balance = 0m;
        }

        public bool Deposit(decimal count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count for deposit must be more then null");
            }
            Balance += count;
            return true;
        }
        public decimal GetBalance() => Balance;
        public bool Withdraw(decimal count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Count for withdraw must be more then null");
            }
            if (Balance < count)
            {
                throw new InvalidOperationException("Not enough money");
            }
            Balance -= count;
            return true;
        }

    }
}
