var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var csp = builder.Configuration["SecurityHeaders:ContentSecurityPolicy"];
var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.UseStaticFiles();
app.UseHttpsRedirection();

// Logging middleware
app.Use(async (context, next) =>
{
    logger.LogInformation("Request: {Method} {Path}", context.Request.Method, context.Request.Path);
    await next.Invoke();
    logger.LogInformation("Response: {StatusCode}", context.Response.StatusCode);
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

//http://localhost:5224/?auth=secret

// CSP middleware
app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", csp);
    await next();
});


// Error simulation route
app.Map("/throw", () =>
{
    throw new Exception("Simulated exception");
});

// Error handler
app.UseExceptionHandler("/error");
app.Map("/error", (HttpContext context) =>
{
    context.Response.ContentType = "text/html";
    return context.Response.SendFileAsync("wwwroot/error.cshtml");
});

// Default route
app.MapGet("/", async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.SendFileAsync("wwwroot/index.cshtml");
});

app.MapFallback(async context =>
{
    context.Response.ContentType = "text/plain";
    context.Response.StatusCode = 404;
    await context.Response.WriteAsync("404 - Page not found");
});


app.Run();
