using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_Demo
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //jagged array is used to overcome the linmitaion of multi-dimentional array memory allocation
            //it is an array of arrays, where each element can have a different length
            int[][] matrix = new int[3][];
            //int [,] matrix = new int[3,]; is it a jagged array? No, this is a multi-dimensional array
            // jagged array is basically an array of arrays. Each elemnt have different length
            matrix[0] = new int[] {1, 2, 3, 4, 5 };
            matrix[1] = new int[] { 6, 7, 8 };
            matrix[2] = new int[] { 9, 10, 11, 12 };
            Console.WriteLine("Jagged array is created successfully.");
            // Displaying the jagged Array
            foreach (var row in matrix)
            {
                foreach (var item in row)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            // Memory consumption by the Jagged array
            Console.Write("Memory consumption by the above Jagged array : ");
            Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(matrix) + " bytes");
            // memory consumption by teh matrix 3x5
            int[,] matrix2 = {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 0 },
                { 11, 12, 13, 14, 15 }
            };
            Console.Write("Memory consumption by the above multi-dimensional array : ");
            Console.WriteLine(System.Runtime.InteropServices.Marshal.SizeOf(matrix2) + " bytes");
            // Memory consumption by the multi-dimensional array
            String[][] sbyteArray = new String[3][]; 
            sbyteArray[0] = new String[] { "Hello", "World" };
            sbyteArray[1] = new String[] { "This", "is", "a", "jagged", "array" };
            sbyteArray[2] = new String[] { "Example", "of", "jagged", "array" };
            Console.WriteLine("Jagged array of strings is created successfully.");
            foreach (var row in sbyteArray)
            {
                foreach (var item in row)
                {
                    Console.Write(string.Join(item + " "));
                }
                Console.WriteLine();
            }
            // Limitation of array in C#
            // 1. fixed Size
            // 2. Type Safety
            // 3. Lack of built-in methods
            // 4. no dyanamic resizing
            // 5. no built-in sorting or searching methods
        }
    }
}
