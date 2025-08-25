// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
//Step 1: Creating a connection object
//Step 2: Creating a command object
//Step 3: Opening the connection
//Step 4: Executing the command
//Step 5: Closing the connection ( we store data in the dataset : Snapshot of database( temp storage)
//Step6: Reading the data using temp variable
//Step 7: Displaying the data

using System.Data;
using System.Data.SqlClient; // Namespace for SQL Server
using System.Xml.Linq;
using Microsoft.Data.SqlClient;

string connectionString = "Data Source=LAPTOP-6IO1N8R8\\SQLEXPRESS02;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

// Step 1
using (SqlConnection conn = new SqlConnection(connectionString))
//passing connection string to the connection object

{
    conn.Open(); // Step 3: Opening the connection
    Console.WriteLine("Connection Opened Successfully");
    string insertQuery = "INSERT INTO Products (Name, Price) VALUES (@name, @price)";
    // Step 2: Creating a command object
    using (SqlCommand cmd = new SqlCommand(insertQuery, conn)) // SQLCommand(query, connection)
    {
        // Adding parameters to prevent SQL injection attack
        cmd.Parameters.AddWithValue("@name", "Sample Product");
        cmd.Parameters.AddWithValue("@price", 19.99);
        int rowsAffected = cmd.ExecuteNonQuery();
        // Step 4: Executing the command
        Console.WriteLine($"{rowsAffected} row(s) inserted.");
    }

    conn.Close(); // Step 5: Closing the connection
    Console.WriteLine("Connection Closed Successfully");
    //reading he data using dataset

    string selectQuery = "SELECT * FROM Products";
    using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
    {
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet dataSet = new DataSet(); // empty dataset 
        adapter.Fill(dataSet); // Filling the dataset with data from the database
        // Step 7: Displaying the data
        foreach (DataRow row in dataSet.Tables[0].Rows)
        {
            Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Price: {row["Price"]}");
        }
    }


}