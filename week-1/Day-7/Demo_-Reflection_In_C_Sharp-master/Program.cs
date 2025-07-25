using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;//for showing metadata at runtime

namespace Demo__Reflection_In_C_Sharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This feature allows us to inspect and interact with metadata.types, properties, methods and assemblies at runtime 

            Type studentType = typeof(Student);// Here student type is of trype student class 
            Console.WriteLine(" Here are the class inforamtion : " + studentType.Name);

            Type EmpType = typeof(Emp);
            Console.WriteLine(" Here the class is : " + EmpType.Name);


            // Fields
            Console.WriteLine(" here are the list of fields in following type ");
            foreach (var field in studentType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance))

            {
                Console.WriteLine($" -{field.Name}: {field.FieldType}");
            }

            //reading properties name and ypes from user define classs 
            Console.WriteLine(" reading properties...!!!");
            foreach (PropertyInfo prop in studentType.GetProperties())
            {
                Console.WriteLine($" -{prop.Name} : {prop.PropertyType}");
            }

            //constrcutors from my class
            Console.WriteLine("readig contructor in my class ");
            foreach (ConstructorInfo ctor in studentType.GetConstructors())
            {
                foreach (ParameterInfo pram in ctor.GetParameters())
                {
                    Console.WriteLine($"{pram.ParameterType.Name}---{pram.Name}");
                }
                Console.WriteLine();
            }

            //reading methods of a class
            Console.WriteLine(" Showing methds defined in a class");
            foreach ( MethodInfo method in studentType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Default | BindingFlags.Static | BindingFlags.DeclaredOnly)) 
            {
                Console.WriteLine($" -{method.Name} --> Retur Type:{method.ReturnType} ");
            }

        }
    }
}
