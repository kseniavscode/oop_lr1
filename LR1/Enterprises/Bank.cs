using System;
using System.Collections.Generic;
using System.Text;

namespace LR1.Enterprises
{
    internal class Bank
    {
        private Guid Id { get; set; }
        private string Name { get; set; }

        public Bank(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
