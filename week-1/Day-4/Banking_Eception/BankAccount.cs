using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Eception
{
    internal class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > Balance)
            {
                throw new InsufficientBalanceException("Insufficient balance for withdrawal.", amount);
            }
            Balance -= amount;
        }
    }
}
