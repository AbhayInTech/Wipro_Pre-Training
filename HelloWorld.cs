using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEmo_getting_Started_with_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Step by step implementation for Arays in C#");
            //Step 1: Declare an array
            //Step 2: Initialize an array
            //Step 3: Access array elements with for loop and foreach loop
            //Step 4: Standard operation on array like sorting, searching, reversing
            //Step 5: Multidimensional array in C#
            //Step 6: Jagged array in C#
            //Step 7: What are different limitation of array hat we can over come via collection types in .NET 

            //Syntax for declaring an array in C# is 
            //dataType[] arrayName = new dataType[size];
            //Example: int[] numbers = new int[5];
            //Array of string type 
            //string[] names = new string[5];
            ////intializing the array of type string 
            //names[0] = "John";
            //names[1] = "Jane";
            //names[2] = "Doe";
            //names[3] = "Alice";
            //names[4] = "Bob";
            ////Initializing the array using array initializer syntax
            ////string[] names = new string[] { "John", "Jane", "Doe", "Alice", "Bob" };
            ////int [] numbers = new int[] { 1, 2, 3, 4, 5 };
            ////Double[] prices = new double[] { 10.99, 20.50, 5.75, 15.00, 30.25 };

            ////using foreach loop to access array elements
            //Console.WriteLine("Accessing array elements using foreach loop:");
            //foreach (string name in names) //read only loop
            //{
            //    Console.WriteLine(name);
            //}
            //Mjor difference between for loop and foreach loop is that 
            //foreach loop is used to iterate over a collection or array without needing to know the index of each element.
            //for loop is used when you need to access elements by their index or when you need to perform operations that require the index.
            //foreach loop is generally more concise and easier to read when you simply want to iterate through all elements of a collection or array.
            //thre are some sceaenrio where we prefer For each loop over for loop
            //for example, when we want to iterate over a collection without modifying it or when we don't need the index of each element.


            //Accessing array elements using for loop, here wew can perform operations that require the index of each element.
            //Console.WriteLine("Accessing array elements using for loop:");
            //for (int i = 0; i < names.Length; i++)
            //{
            //    Console.WriteLine($"Element at index {i}: {names[i]}");
            //}

            ////Sorting an array of number based on salary 
            //double[] salaries = new double[] { 50000.00, 60000.00, 45000.00, 70000.00, 55000.00 };
            //Console.WriteLine("Salaries before sorting:");
            //foreach (double salary in salaries)// simple display of salaries
            //{
            //    Console.WriteLine(salary);
            //}

            ////Sorting the array of salaries in ascending order
            //Array.Sort(salaries);
            //Console.WriteLine("Salaries after sorting:");
            //foreach (double salary in salaries)
            //{
            //    Console.WriteLine(salary);
            //}

            //sorting array od string based on alphabetical order for movie array
            //string[] movies = new string[] { "Inception", "The Dark Knight", "Interstellar", "Pulp Fiction", "The Shawshank Redemption" };
            //Console.WriteLine("Movies before sorting:");
            //foreach (string movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}

            ////Sorting the array of movies in alphabetical order
            //Array.Sort(movies);
            //Console.WriteLine("Movies after sorting:");
            //foreach (string movie in movies)
            //{
            //    Console.WriteLine(movie);
            //}
            ////Reversing an array of numbers
            //Console.WriteLine("Salaries before reversing:");
            //foreach (double salary in salaries)
            //{
            //    Console.WriteLine(salary);
            //}
            ////Reversing the array of salaries
            //Array.Reverse(salaries);
            //Console.WriteLine("Salaries after reversing:");
            //foreach (double salary in salaries)
            //{
            //    Console.WriteLine(salary);
            //}
            // searching for specifc movie in the array of movies
            //asking user for inputing the movie name to search
            //Console.WriteLine("Enter the movie name to search:");
            //string searchMovie = Console.ReadLine(); // Uncomment this line to take input from user
            ////string searchMovie = "Inception";
            //int movieIndex = Array.IndexOf(movies, searchMovie);// Searching for the index of the movie "Inception"

            //Console.WriteLine(movieIndex);//showing index of the searched movie
            ////also wan to show moview name found at index:
            //if (movieIndex != -1)
            //{
            //    Console.WriteLine($"Movie '{searchMovie}' found at index: {movieIndex}");
            //}
            //else
            //{
            //    Console.WriteLine($"Movie '{searchMovie}' not found in the array.");
            //}

            //Displaying the index of the searched movie with a message Moview name found at index:


            //if we wish to perform earching and evering operaion on array, we can use the Array class methods
            //Searching for an element in the array using Array.IndexOf method
            //string searchName = "Alice";
            //int index = Array.IndexOf(names, searchName);


            //As a developer we need to work on seat booking system, we can use array to store the seat numbers and their availability status.
            //thre are 50 rows and 10 columns of seats in the theatre, we can use a 2D array to represent the seating arrangement.
            //intially all seats are avialble, when a user books a seat it shul dbe marked as booked.
            //We need to create a logic for displaying the seatcing arrangement , allowing users to book seats, and displaying the booked seats.
            //Creating a 2D array to represent the seating arrangement

            //Step 1: Declare a 2D array for seating arrangement with rows and columns
            //Step 2: Initialize the 2D array with seat numbers and availability status
            //Step 3: Display the seating arrangement after initialization and before booking
            //Step 4: Allow users to book seats by selecting a seat number
            //Step 5: Display the seating arrangement after booking


            //As per step 1: Declare a 2D array for seating arrangement with rows and columns
            int rows = 5; // Number of rows in the theatre
            // Number of columns in the theatre
            int columns = 5; // Number of columns in the theatre
            //Step 2: Initialize the 2D array with seat numbers and availability status
            string[,] seatingArrangement = new string[rows, columns];// 2D array to represent the seating arrangement
            //Step 3: Display the seating arrangement after initialization and before booking
            Console.WriteLine("Seating Arrangement:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Initializing seat numbers in the format "Row-Column"
                    seatingArrangement[i, j] = $"|(A)|-{i + 1}-{j + 1}";
                }
                // Displaying the seating arrangement
                //Console.WriteLine(string.Join(" ", seatingArrangement.Cast<string>().Skip(i * columns).Take(columns)));
                // in  above statement is used to format the output of each row of seats where
                // here we are using Sring .Join to join the elements of the array with a space separator
                // and Cast<string>() is used to convert the 2D array to a 1D array for formatting
                //then  we are using skip(i * columns) to skip the elements of the previous rows
                //take(columns) is used to take the elements of the current row



                //displaying each row of seatsfor my 2D array using for loop
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(seatingArrangement[i, j] + " "); // Displaying each seat in the row
                }


                // Displaying each row of seats and using string.Join to format the output along with seat numbers using cast and skip methods
            }

            //Step 4: Allow users to book seats by selecting a seat number
            Console.WriteLine("Enter the row number (1 to 5) to book a seat:");
            int selectedRow = Convert.ToInt32(Console.ReadLine()) - 1; // User input for row number (1 to 5)
            Console.WriteLine("Enter the column number (1 to 5) to book a seat:");
            int selectedColumn = Convert.ToInt32(Console.ReadLine()) - 1; // User input for column number (1 to 5)
            // Step 5: Check if the selected seat is available and book it
            if (selectedRow >= 0 && selectedRow < rows && selectedColumn >= 0 && selectedColumn < columns)
            {
                // Check if the seat is already booked
                if (seatingArrangement[selectedRow, selectedColumn].Contains("Booked"))
                {
                    Console.WriteLine("Sorry, this seat is already booked.");
                }
                else
                {
                    // Mark the seat as booked
                    seatingArrangement[selectedRow, selectedColumn] = $"|(B)|-{selectedRow + 1}-{selectedColumn + 1}"; // Marking the seat as booked
                    Console.WriteLine($"Seat at Row {selectedRow + 1}, Column {selectedColumn + 1} has been booked successfully.");
                }
            }
            else
            {
                Console.WriteLine("Invalid seat selection. Please try again.");
            }

            //displaying the seating arrangement after booking
            Console.WriteLine("Seating Arrangement after booking:");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(seatingArrangement[i, j] + " "); // Displaying each seat in the row
                }
                Console.WriteLine(); // Move to the next line after displaying each row
            }


        }
    }
}
