using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Eception
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new Banking_Eception.BankAccount(1000);

            try
            {   
                Console.WriteLine("How much do you want to withdraw : ");
                double amountToWithdraw = Convert.ToDouble(Console.ReadLine());
                account.Withdraw((decimal)amountToWithdraw);
                Console.WriteLine($"Withdrawal successful! New balance: {account.Balance}");
            }
            catch (Banking_Eception.InsufficientBalanceException ex)
            {
                Console.WriteLine($"{ex.Message} Attempted withdrawal: {ex.AttemptedWithdrawal}");
            }
        }
    }
}
