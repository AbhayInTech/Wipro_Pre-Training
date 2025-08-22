// Add a reference to the System.Data.SqlClient NuGet package if you are using .NET Core or .NET 5+
// In Visual Studio: Right-click your project > Manage NuGet Packages > Search for "System.Data.SqlClient" > Install

using System;
using System.Data;
using System.Data.SqlClient; // Ensure this using directive is present
using Microsoft.Data.SqlClient; // For .NET Core or .NET 5+
using System.Data.Common;

// Connection string to your SQL Server
string connectionString = "Data Source=LAPTOP-6IO1N8R8\\SQLEXPRESS02;Initial Catalog=CollegeDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

try
{
    // Create and open the connection
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        // Create the command
        SqlCommand cmd = new SqlCommand("SELECT * FROM Student", conn);

        // Open connection
        conn.Open();

        // Execute reader
        SqlDataReader reader = cmd.ExecuteReader();

        // Read and display data
        while (reader.Read())
        {
            Console.WriteLine($"{reader["studentID"]} {reader["FullName"]} {reader["Email"]} {reader["Age"]}");
        }

        // Close reader
        reader.Close();
    }
}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}

// Pause to view output
Console.WriteLine("\nPress any key to exit...");
Console.ReadKey();
