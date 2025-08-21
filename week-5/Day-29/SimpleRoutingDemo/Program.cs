var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//registering Custom Route constraint
builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("even", typeof(EvenConstraint));
    options.ConstraintMap.Add("odd", typeof(OddConstraint));

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

//Adding custom routing Endpoints

app.MapControllerRoute(
    name: "even",
    pattern: "number/even/{id:even}",
    defaults: new { controller = "Home", action = "EvenOnly" });

app.MapControllerRoute(
    name: "odd",
    pattern: "number/odd/{id:odd}",
    defaults: new { controller = "Home", action = "OddOnly" });

app.MapControllerRoute(
    name: "any",
    pattern: "number/any/{id:int}",
    defaults: new { controller = "Home", action = "AnyID" });

app.MapControllerRoute(
    name: "special",
    pattern: "number/special",
    defaults: new { controller = "Home", action = "Special" });


app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
