using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Getting started with Collections
            // Types of Collections
            // 1. Array
            // 2. List : it can store a collection of objecs
            // 3. Dictionary
            // 4. HashSet
            // 5. Queue
            // 6. Stack
            // 7. LinkedList
            // 8. SortedList
            // 9. SortedDictionary
            // 10. SortedSet
            // 11. Concurrent Collections

            // We can categorize collections into two types:

            // A. Generic Collections: These collections are type-safe and provide better performance.
            // Types of Generic Collections:

            // 1. List<T>: A generic collection that can store a list of objects of type T.

            // Senario to implement Array list of geeneric collection based on Employee name
            List<String> employeeNames = new List<string>();
            // Adding employee names to the list
            employeeNames.Add("John Doe");  
            employeeNames.Add("Jane Smith");
            employeeNames.Add("Alice Johnson");
            employeeNames.Add("Bob Brown");
            employeeNames.Add("Charlie Davis");
            // update an employee name in the list
            employeeNames[2] = "Alice Williams";

            Console.WriteLine("Employee Names");
            // Display the list of employee names
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }
            // Remove an employee name from the list
            employeeNames.Remove("Jane Smith");
            // Display the updated list of employee names
            Console.WriteLine("\nAfter removing Jane Smith:");
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }
            // search for an employee name in the list
            string searchName = "Alice Johnson";
            if (employeeNames.Contains(searchName))
            {
                Console.WriteLine($"\n{searchName} is found in the list.");
            }
            else
            {
                Console.WriteLine($"\n{searchName} is not found in the list.");
            }
            // Sort the list of employee names
            employeeNames.Sort();
            Console.WriteLine("\nSorted Employee Names:");
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }
            // Count the number of employee names in the list (count is a property of List<T>)
            int count = employeeNames.Count;
            Console.WriteLine($"\nTotal number of employee names: {count}");
            // Clear the list of employee names
            //employeeNames.Clear();
            //Console.WriteLine("\nAfter clearing the list, count is: " + employeeNames.Count);
            

            // Lets insert element in collection using input from user bases on int values is salaries of an employee
            List<int> employeeSalaries = new List<int>();
            Console.WriteLine("\nEnter employee salaries (type 'done' to finish):");
            // reading salaries from user input
            foreach (var input in employeeNames)
            {
                Console.Write($"Enter salary for {input}: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "done")
                {
                    break; // Exit the loop if the user types 'done'
                }
                if (int.TryParse(userInput, out int salary))
                {
                    employeeSalaries.Add(salary); // Add the salary to the list
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer salary.");
                }
                Console.WriteLine(employeeNames.Count > 0 ? "\nEmployee Salaries:" : "No employee salaries entered.");
                // Showing the count of the collection
                Console.WriteLine($"Total number of employee salaries: {employeeSalaries.Count}");
                // Display the list of employee salaries
                foreach (var salaryValue in employeeSalaries)
                {
                    Console.WriteLine(salaryValue);
                }
                // showing the size of the collection
                Console.WriteLine(employeeSalaries.Capacity);
                Console.WriteLine(employeeSalaries.Count);
            }


            // 2. Dictionary<TKey, TValue>: A generic collection that stores key-value pairs.
            // 3. HashSet<T>: A generic collection that stores unique elements of type T.
            // 4. Queue<T>: A generic collection that stores elements in a first-in-first-out (FIFO) order.
            // 5. Stack<T>: A generic collection that stores elements in a last-in-first-out (LIFO) order.

            // B. Non-Generic Collections: These collections can store any type of object, but they are not type-safe.

        }
    }
}
