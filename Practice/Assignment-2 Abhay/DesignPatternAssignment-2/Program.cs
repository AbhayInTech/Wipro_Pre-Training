
using DesignPatternAssignment_2;
using System;
using System.Reflection.Metadata;
using Document = DesignPatternAssignment_2.Document;

namespace DesignPatternFactoryDemo
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter document type (PDF/Word):");
            string input = Console.ReadLine();

            try
            {
                Document doc = DocumentFactory.Create(input);
                doc.Print();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}