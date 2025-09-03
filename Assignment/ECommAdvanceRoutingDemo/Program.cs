var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddSingleton<ECommAdvanceRoutingDemo.CustomConstraints.PriceRangeConstraint>();

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

app.UseSession();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "productFilter",
    pattern: "Products/Filter/{category}/{priceRange}",
    defaults: new { controller = "Products", action = "Filter" },
    constraints: new { priceRange = new ECommAdvanceRoutingDemo.CustomConstraints.PriceRangeConstraint() });

app.MapControllerRoute(
    name: "productDetails",
    pattern: "Products/{category}/{id}",
    defaults: new { controller = "Products", action = "Details" });

app.MapControllerRoute(
    name: "productIndex",
    pattern: "Products/{category}",
    defaults: new { controller = "Products", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
