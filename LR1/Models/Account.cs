using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Models
{
    internal class Account
    {
        private Guid Id {  get; set; }
        private Guid ClientId { get; set; }
        private decimal Balance { get; set; }

        public Account(Guid clientId)
        {
            Id = Guid.NewGuid();
            ClientId = clientId;
            Balance = 0m;
        }
    }
}
