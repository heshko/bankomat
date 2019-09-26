using System;
using System.Collections.Generic;
using System.Text;

namespace bankomat.Domain
{

    abstract class Card
    {
        public string PinCode { get; set; }

        public string CardNumber { get; set; }

        public Account Account { get; set; }

      protected   Card(string cardNumber, string pinCode, Account account)
        {
            CardNumber = cardNumber;
            PinCode = pinCode;
            Account = account;
        }

        public abstract bool Withdraw(decimal amount);
    }
}

