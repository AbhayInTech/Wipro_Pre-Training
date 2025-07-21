using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_Manipulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //different method to declare array and initialize it
            // 1. Declare and initialize with size and values
            int[] arr1 = new int[5] { 1, 2, 3, 4, 5 };

            // 2. Declare and initialize without specifying size
            int[] arr2 = { 6, 7, 8, 9, 10 };

            // 3. Declare with size only (default values)
            int[] arr3 = new int[3]; // All elements are 0

            // 4. String array initialization
            string[] strArr1 = new string[3] { "apple", "banana", "cherry" };
            string[] strArr2 = { "dog", "cat", "bird" };

            // 5. Using var keyword (type inference)
            var arr4 = new[] { 11, 12, 13 };

            // 6. Multidimensional array
            int[,] multiArr = new int[3, 2] { { 1, 2 }, { 3, 4 }, {5, 6}};

            // 7. Jagged array (array of arrays)
            int[][] jaggedArr = new int[2][];
            jaggedArr[0] = new int[] { 1, 2 };
            jaggedArr[1] = new int[] { 3, 4, 5 };

            // 8. Accessing and modifying array elements
            arr1[0] = 100; // Set first element to 100
            int value = arr1[2]; // Get third element

            // 9. Array Length property
            int len = arr1.Length; // Gets the number of elements

            // 10. Iterating with for loop (index-based)
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.WriteLine(arr1[i]);
            }

            // 11. Using Array class methods
            Array.Sort(arr1); // Sorts the array
            Array.Reverse(arr1); // Reverses the array
            int idx = Array.IndexOf(arr1, 5); // Finds index of value 5
            Console.WriteLine(Array.IndexOf(arr1, 6));
            Console.WriteLine(Array.IndexOf(arr1, 4));
            // 12. Copying arrays
            int[] arrCopy = new int[arr1.Length];
            Array.Copy(arr1, arrCopy, arr1.Length);
            Console.WriteLine(arrCopy);
  
            for(int i=0; i<arrCopy.Length; i++)
            {
                Console.WriteLine(i);
            }

            int[] arrCpy = arr1;
            Console.WriteLine(arrCpy);
            for (int i = 0; i < arrCpy.Length; i++)
            {
                Console.WriteLine(i);
            }

            // 13. Passing arrays to methods
            void PrintArray(int[] arr)
            {
                foreach (var item in arr)
                    Console.WriteLine(item);
            }
            PrintArray(arr1);

            // 14. Returning arrays from methods
            int[] CreateArray(int size)
            {
                int[] result = new int[size];
                for (int i = 0; i < size; i++)
                    result[i] = i * i;
                return result;
            }
            int[] squares = CreateArray(5);

            // 15. Using LINQ with arrays
            var evenNumbers = arr1.Where(x => x % 2 == 0).ToArray();

            // 16. Array.Clear to reset elements
            Array.Clear(arr1, 0, arr1.Length); // Sets all elements to default (0)

            // 17. Foreach with multidimensional arrays
            foreach (int item in multiArr)
            {
                Console.WriteLine(item);
            }

            // 18. Array resizing (using Array.Resize)
            Array.Resize(ref arr1, 10); // Changes size to 10

            // 19. Checking if array contains a value
            bool hasValue = arr1.Contains(5);

            // 20. Converting array to List
            List<int> list = arr1.ToList();

            //21. Using ForEach loop for arrays
            foreach (int i in arr1)
            {
                Console.WriteLine(i);
            }

        }
    }
}
