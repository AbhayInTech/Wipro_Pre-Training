var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register custom route constraints
builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("customguid", typeof(AdvanceRoutingDemo.Constraints.GuidConstraint));
});

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
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Complex routes
app.MapControllerRoute(
    name: "productsIndex",
    pattern: "Products/{category}",
    defaults: new { controller = "Products", action = "Index" });

app.MapControllerRoute(
    name: "products",
    pattern: "Products/{category}/{id}",
    defaults: new { controller = "Products", action = "Details" });

app.MapControllerRoute(
    name: "users",
    pattern: "Users/{username}/Orders",
    defaults: new { controller = "Users", action = "Orders" });

// Route with custom constraint
app.MapControllerRoute(
    name: "productByGuid",
    pattern: "Product/{id:customguid}",
    defaults: new { controller = "Products", action = "DetailsByGuid" });

app.Run();
