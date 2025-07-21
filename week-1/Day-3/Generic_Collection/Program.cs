using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_Collection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Need to implement stack and queue using generic collection in C#
            // Scenario: need to create a C# program that maintains Browser navigation / URL history and printout job queues using Stack and Queue.
            // Stack: Last In First Out (LIFO)- Used for browser navigation history
            // Queue: First In First Out (FIFO) - Used for print job queues
            // Step 1: Create a stack for browser navigation history
            // Step 2: Create a queue for print job queues
            // Step 3: Implement methods to push and pop URLs in the stack
            // Step 4: Implement methods to enqueue and dequeue print jobs in the queue
            // Step 5: Print the current state of the stack and queue
            // Step 6: Test the program with sample data

            Stack<string> browserHistory = new Stack<string>();

            Queue<string> printJobs = new Queue<string>();

            // Step 3: Push and pop URLs in the stack
            browserHistory.Push("https://www.google.com");
            browserHistory.Push("https://www.microsoft.com");
            browserHistory.Push("https://www.amazon.com");
            browserHistory.Push("https://flipkart.in");

            Console.WriteLine("Browser History (Top to Bottom):");
            foreach (var url in browserHistory)
            {
                Console.WriteLine(url);
            }

            Console.WriteLine("\nRemoving a URL history last inserted: " + browserHistory.Pop());

            Console.WriteLine("Current Browser History:");
            foreach (var url in browserHistory)
            {
                Console.WriteLine(url);
            }

            // Step 4: Enqueue and dequeue print jobs in the queue
            printJobs.Enqueue("Resume1.pdf");
            printJobs.Enqueue("Resume2.docx");
            printJobs.Enqueue("Resume3.xlsx");
            printJobs.Enqueue("Resume4.pptx");

            Console.WriteLine("\nPrint Job Queue (Front to Back):");
            foreach (var job in printJobs)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("\nRemoving the document from the front : " + printJobs.Dequeue());

            Console.WriteLine("Current Print Job Queue:");
            foreach (var job in printJobs)
            {
                Console.WriteLine(job);
            }


        }
    }
}
