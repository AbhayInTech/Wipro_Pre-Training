using System;
using System.Threading.Tasks;

namespace Student_Grade_Estimator
{
    internal class Program
    {
        public static void Main(string[] args)
        {   
            Console.WriteLine($"{Math.Sqrt(25)}");
            Console.WriteLine($"{Math.Abs(-10)}");
            Console.WriteLine($"{Math.Pow(10,5)}");

            Console.WriteLine("welcome to Student Grade Estimator System");
            Console.WriteLine("");
            Console.Write("Enter the Total Marks : ");
            double total = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the marks of the Sudent : ");
            double marks = Convert.ToDouble(Console.ReadLine());
            if (marks > total)
            {
                Console.WriteLine("Invalid Marks");
            }
            else
            {
                double percentage = (marks / total) * 100;
                Console.WriteLine($"Obtained Percentage : {percentage}");
                string result = (percentage < 40)? "failed" : "passed";
                Console.WriteLine($"Status : {result}");
                if (percentage >= 90)
                {
                    Console.WriteLine("Grade A+");
                }
                else if (percentage >= 80)
                {
                    Console.WriteLine("Grade  B+");
                }
                else if (percentage >= 70)
                {
                    Console.WriteLine("Grade  C");
                }
                else if (percentage >= 60)
                {
                    Console.WriteLine("Grade  D");
                }
                else if (percentage >= 40)
                {
                    Console.WriteLine("Grade  E");
                }
                else
                {
                    Console.WriteLine("Failed");
                }
            }
        }
    }
}