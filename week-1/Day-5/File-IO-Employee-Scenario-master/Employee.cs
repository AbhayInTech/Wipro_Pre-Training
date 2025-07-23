using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json; // Ensure you have Newtonsoft.Json package installed for JSON serialization/deserialization

namespace File_IO_Employee_Scenario
{

    public class Employee
    {
        public int empID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

        //public Employee()
        //{
        //    empID = 0;
        //    Name = "";
        //    Salary = 0;
        //}
        //public Employee(int ID, string name, decimal salary)
        //{
        //    empID = ID;
        //    Name = name;
        //    Salary = salary;
        //}

        public static List<Employee> employees = new List<Employee>();
         string filepath = "employee.txt"; // Default file path for saving employees
        public override string ToString()
        {
           return ($"Employee ID: {empID}, Name: {Name}, Salary: {Salary}");
        }

        public void Savetofile(string filepath)
        {
            using (var writer = new System.IO.StreamWriter(filepath, true))
            {
                writer.WriteLine($"{empID},{Name},{Salary}");
            }
        }
        public void Addfile(List<Employee> employees,string filepath)
        {
            Console.WriteLine("enter the employee id ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter the employee name ");
            string name = Console.ReadLine();
            Console.WriteLine("enter the employee salary ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            this.empID = id;
            this.Name = name;
            this.Salary = salary;
            employees.Add(this);
            this.Savetofile(filepath);
            Console.WriteLine("Employee added successfully!");
        }

        public void Viewall(List<Employee> employees)
        {
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.ToString());
                Console.WriteLine("\n");
            }
        }

        public void Searchbyid()
        {
            Console.WriteLine("enter the employee id to search");
            int id = Convert.ToInt32(Console.ReadLine());
            var emp = employees.FirstOrDefault(e => e.empID == id);
            if (emp != null)
            {
                Console.WriteLine(emp.ToString());
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void Deletebyid()
        {
            Console.WriteLine("enter the employee id to delete");
            int id = Convert.ToInt32(Console.ReadLine());
            var emp = employees.FirstOrDefault(e => e.empID == id);
            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee deleted successfully!");
                // Optionally, you can also remove the line from the file
                // This would require reading the file, removing the line, and writing back
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }
        public void Updatebyid()
        {
            Console.WriteLine("enter the employee id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            var emp = employees.FirstOrDefault(e => e.empID == id);
            if (emp != null)
            {
                Console.WriteLine("enter the new name");
                emp.Name = Console.ReadLine();
                Console.WriteLine("enter the new salary");
                emp.Salary = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Employee updated successfully!");
                // Optionally, you can also update the line in the file
                // This would require reading the file, updating the line, and writing back
            }
            else
            {
                Console.WriteLine("Employee not found");
            }
        }

        public void SaveEmployeesToFile()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(employees); // Serialize the list of employees to a JSON string
            File.WriteAllText(filepath, json); // Write the JSON string to the file
            Console.WriteLine("Employees saved successfully.");
        }
        public void LoadfromFile(string filepath)
        {
            if (File.Exists(filepath)) // Check if the file exists
            {
                
                var json = File.ReadAllText(filepath); // Read the JSON string from the file
                employees = System.Text.Json.JsonSerializer.Deserialize<List<Employee>>(json); // Deserialize the JSON string to a list of employees
                //employees = Newtonsoft.Json.JsonSerializer<List<Employee>>(json)!;
                Console.WriteLine("Employees loaded successfully.");
            }
            else
            {
                Console.WriteLine("File not found. No employees loaded.");
            }
        }

       
    }
}
