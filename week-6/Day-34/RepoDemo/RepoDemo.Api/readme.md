Steps for implementing repository pattern in ASP.NET EF core :

Step 1: Create solution and API project using CLI

Step 2: Adding EF core packages along with connection string

Sep 3: Create the Domain Model( Product)

Step 4: Create the EF DBContext

Step 5: Wireup DBContext in DI( Program.cs)

Step 6: Create an Repository interface ( repositories/Interfaces/IGenericreposiory.cs)

Step 7: Implement the Generic repository & Unit of Work

Step 8: Creating the controller that is going to use the repository.

Step 9: Creating the data with migrations.

Step 10: Running and testing your application

//The Objective of creating a repository is to provide a centralized location for

//data access logic, promoting separation of concerns and making the application easier to maintain and test.

dotnet ef migrations add InitialCreate

dotnet ef database update
