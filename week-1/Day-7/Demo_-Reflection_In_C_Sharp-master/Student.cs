using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo__Reflection_In_C_Sharp
{
    public class Student
    {
        private int id;
        public string Name { get; set; }
        public int Age { get; set; }
        public Student(int id, string name, int age)
        {
            this.id = id;
            this.Name = name;
            this.Age = age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($" Student: {Name}, Age: {Age}");
        }
        public int getId() { return id; }
        public string GetName() { return Name; }
    }

    public class Emp
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; }
        public int Age { get; set; }
    }

     
}
