using System.Data;
using Microsoft.Data.SqlClient;

namespace MvcADO_Demo.Data;

//Here i have to create a class called ProductsRepository so that it can be 
//used as reference in the controllers

public class ProductsRepository
{
    private readonly IDbConnection _dbConnection;

    public ProductsRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
        //above line allows us to use the injected IDbConnection instance 
        // ie default connection string
    }

    // Insert a product into the database
    public int InsertProduct(string name, double price)
    {
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO Products (Name, Price) VALUES (@Name, @Price); SELECT SCOPE_IDENTITY();";
        command.Parameters.Add(new SqlParameter("@Name", name));
        command.Parameters.Add(new SqlParameter("@Price", price));
        connection.Open();
        var result = command.ExecuteScalar();
        connection.Close();
        return Convert.ToInt32(result);
    }

    // filling dataset snapshot of the data
    public DataSet GetProducts()
    {
        var dataSet = new DataSet(); // dataset is used to hold the result set
        using var connection = _dbConnection;
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Products"; // Selecting all products
        using var adapter = new SqlDataAdapter((SqlCommand)command);
        //using Adapter with DataSet helps us to open/close automatically
        adapter.Fill(dataSet); // Filling the dataset with the result set
        return dataSet;
    } // we can also have data table as return type
}