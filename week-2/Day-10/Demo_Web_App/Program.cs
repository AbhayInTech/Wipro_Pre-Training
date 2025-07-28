var builder = WebApplication.CreateBuilder(args);
// Adding MVC

builder.Services.AddControllersWithViews(); // Add MVC services
var app = builder.Build();

app.MapGet("/", () => "Hello World!");// Minal API endpoint

app.MapGet("/Mobilephones", () => new[] { "Samsung", "Nokia" });

app.MapGet("/RepeatNames", (string name, int count) => Enumerable.Repeat(name, count).ToList());

//Adding MVC Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


//Add multiple different Routes

app.Run();

// Step 1: Run this template as it is:
// Step 2: Add a new controller named HomeController.cs in the Controllers folder
