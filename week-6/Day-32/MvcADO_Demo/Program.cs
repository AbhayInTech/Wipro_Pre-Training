using System.Data;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddScoped<IDbConnection>(db => new SqlConnection(builder.Configuration.GetConnectionString("Default")));

//Above service integration allows us to inject IDbConnection into our controllers hence 

//we can access the database easily.

// Register our ADO.NET Services
builder.Services.AddScoped<MvcADO_Demo.Data.ProductsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
// MvcADO_Demo working perfectly to get the data from the database using ADO.NET
// and display it in the view using ADO.NET approach