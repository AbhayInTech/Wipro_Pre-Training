using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexer_Demo
{
    // A class with an indexer
    class MyCollection
    {
        private int[] data = new int[5]; // Backing array

        // Indexer definition
        public int this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection obj = new MyCollection();

            // Setting values using indexer
            obj[0] = 10;
            obj[1] = 20;
            obj[2] = 30;

            // Getting values using indexer
            Console.WriteLine("Values from MyCollection:");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"obj[{i}] = {obj[i]}");
            }

            Console.ReadLine(); // Keeps console window open
        }
    }
}
