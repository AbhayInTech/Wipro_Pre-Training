using Microsoft.EntityFrameworkCore;
using SMD_Backend.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Add DbContext
builder.Services.AddDbContext<DataDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
