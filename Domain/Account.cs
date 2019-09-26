using System;
using System.Collections.Generic;
using System.Text;

namespace bankomat.Domain
{
    class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public Account(decimal balance)
        {
            Balance = balance;
        }
    }
}
