using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Eception
{
    internal class InsufficientBalanceException:Exception
    {

        //step 1: Create a custom exception class
        //step 2: Inherit from Exception class
        //step 3: Create a constructor that takes a message parameter and passes it to the base class constructor
        //step 4: Optionally, you can add additional properties or method if needed
        //step 5: Use a custom exception in your banking application where you validate balance
        //create a class with bank account and a method to withdraw money
        //Your class should have Balance property with a getter and private setter
        // Property for attempted withdrawal
        public decimal AttemptedWithdrawal { get; }

        public InsufficientBalanceException(string message, decimal attemptedWithdrawal)
            : base(message)
        {
            AttemptedWithdrawal = attemptedWithdrawal;
        }
    }

    
}