var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



//Conventional Routing Configuration
    app.MapControllerRoute(
        name: "about",
        pattern: "about-us",
        defaults: new { controller = "Home", action = "About" }
    );
     app.MapControllerRoute(
        name: "contact",
        pattern: "contact/{department?}",
        defaults: new { controller = "Home", action = "Contact" }
    );
     app.MapControllerRoute(
        name: "products",
        pattern: "products",
        defaults: new { controller = "Products", action = "Index" }
    );
      app.MapControllerRoute(
        name: "product-details",
        pattern: "products/details/{id}",
        defaults: new { controller = "Products", action = "Details" }
    );
    //Default route should be last
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
