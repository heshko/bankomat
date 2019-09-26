using System;
using System.Collections.Generic;
using System.Text;

namespace bankomat.Domain
{
    class CreditCard : Card
    {
        public decimal CreditLimit { get; set; }
        public decimal CreditBalance { get; set; }
        public CreditCard(string cardNumber, string pinCode, Account account, decimal creditLimit) : base(cardNumber, pinCode, account)
        {
            CreditLimit = creditLimit;
        }
        public override bool Withdraw(decimal amount)
        {

            if (amount < 0)
            {
                throw new ArgumentException("amount cannot be negative");
            }



            if ((Account.Balance + CreditLimit)>=amount)
            {
                Account.Balance = -amount;
               

                return true;
            }

            return false;
        }

    }
   
}
