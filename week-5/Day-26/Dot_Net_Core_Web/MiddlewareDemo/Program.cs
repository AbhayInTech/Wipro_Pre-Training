var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


// Middleware 1: Logs all requests
app.Use(async (context, next) =>
{
    Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
    await next.Invoke();
});


// Middleware 2: Simple Authentication check
app.Use(async (context, next) =>
{
    if (context.Request.Query.TryGetValue("auth", out var authkey) && authkey == "secret")
    {
        await next();
    }
    else
    {
        context.Response.StatusCode = 401; // Unauthorized
        await context.Response.WriteAsync("Unauthorized");
    }
});

//Execption handling middleware
app.UseExceptionHandler("/error");

// Ststic file serving middleware
app.UseStaticFiles();

app.MapGet("/", () => "Hello World!");

app.MapGet("/error", () => "An error occurred!");

app.Run();
