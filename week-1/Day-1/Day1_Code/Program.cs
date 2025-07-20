using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1_Code
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here is Demo based on looping constructs and variables types in C# using a ");
            Console.WriteLine("Enter first Number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose an operator: +, -, *, /");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "+":
                    Console.WriteLine($"result : {num2 + num1}");
                    break;
                case "-":
                    Console.WriteLine($"result : {num2 - num1}");
                    break;
                case "*":
                    Console.WriteLine($"result : {num2 * num1}");
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        Console.WriteLine($"result  : {num1 / num2}");
                    }
                    else
                    {
                        Console.WriteLine("Number can't be divided by 0");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operation selected.");
                    return;

            }
        }
    }
}
