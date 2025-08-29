using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JwtCookieDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//here we add cookies and service
builder.Services.AddAuthentication(options =>

{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? throw new InvalidOperationException("JWT Key is not configured.")))
    };
});

//Authorization : role and claim based policies is added here so that only authorized users can access 

//certain endpoints

builder.Services.AddAuthorization(options =>

{

    options.AddPolicy("AdminOnly", policy =>

        policy.RequireRole("Admin")); //This method adds a policy requiring the user to be in the Admin role

    options.AddPolicy("EmployeeOnly", policy =>

        policy.RequireClaim("EmployeeNumber")); // this method adds a policy requiring the user to have a specific claim ie EmployeeNumber

});


//Authorization : role and claim based policies is added here so that only authorized users can access 

//certain endpoints

builder.Services.AddAuthorization(options =>

{

    options.AddPolicy("AdminOnly", policy =>

        policy.RequireRole("Admin")); //This method adds a policy requiring the user to be in the Admin role

    options.AddPolicy("EmployeeOnly", policy =>

        policy.RequireClaim("EmployeeNumber")); // this method adds a policy requiring the user to have a specific claim ie EmployeeNumber

});




//Authorization : role and claim based policies is added here so that only authorized users can access 

//certain endpoints

builder.Services.AddAuthorization(options =>

{

    options.AddPolicy("AdminOnly", policy =>

        policy.RequireRole("Admin")); //This method adds a policy requiring the user to be in the Admin role

    options.AddPolicy("EmployeeOnly", policy =>

        policy.RequireClaim("EmployeeNumber")); // this method adds a policy requiring the user to have a specific claim ie EmployeeNumber

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


app.Run();
