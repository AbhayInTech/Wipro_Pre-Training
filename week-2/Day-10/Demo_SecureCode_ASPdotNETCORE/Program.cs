var builder = WebApplication.CreateBuilder(args);

// Adding HTTPs redirection (Forces Secure Connections)
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443; // Default HTTPS port
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Middleware orders Matters
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
