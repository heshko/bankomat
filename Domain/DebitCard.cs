using System;
using System.Collections.Generic;
using System.Text;

namespace bankomat.Domain
{
    class DebitCard : Card
    {
        public DebitCard(string cardNumber, string pinCode, Account account)
            : base(cardNumber, pinCode, account)
        {

        }

        public override bool Withdraw(decimal amount)
        {
            {
                if (amount < 0)
                {
                    throw new ArgumentException("amount cannot be negative");
                }

                if (Account.Balance >= amount)
                {
                    Account.Balance -= amount;

                    return true;
                }

                return false;
            }
        }
    }
}
