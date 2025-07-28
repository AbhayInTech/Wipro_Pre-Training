var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

// this is simpler than MVC , but it is not as powerful
// Direct data binding with PageModal Properties
// Clear separation of markup and logic
// Your program.cs is simpler and have separate files for each page for better organization
// Razor Pages is a page-based programming model that makes buildinng web Ui simpler.

