using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_IO_Employee_Scenario
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee();
            string filepath = "employee.txt";
            while (true)
            {
                Console.WriteLine("Enter the choice from the below menu");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search");
                Console.WriteLine("4. Save");
                Console.WriteLine("5. Load");
                Console.WriteLine("6. Delete");
                Console.WriteLine("7. Update");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                int choice;
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        emp.Addfile(Employee.employees, filepath);
                        break;
                    case 2:
                        emp.Viewall(Employee.employees);
                        break;
                    case 3:
                        emp.Searchbyid();
                        break;
                    case 4:
                        emp.SaveEmployeesToFile();
                        break;
                    case 5:
                        emp.LoadfromFile(filepath);
                        break;
                    case 6:
                        emp.Deletebyid();
                        break;
                    case 7:
                        emp.Updatebyid();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }
    }
}





