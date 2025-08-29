using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RoleAuthDemo.Models;
using System;
using System.Threading.Tasks;

namespace RoleAuthDemo.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = new[] { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Create admin user
            var adminEmail = "admin@example.com";
            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser { UserName = "admin", Email = adminEmail, DisplayName = "Administrator" };
                var result = await userManager.CreateAsync(admin, "Admin@123"); // Identity will hash the password
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "Admin");
                }
            }

            // Create normal user
            var userEmail = "user1@example.com";
            var user1 = await userManager.FindByEmailAsync(userEmail);
            if (user1 == null)
            {
                user1 = new ApplicationUser { UserName = "user1", Email = userEmail, DisplayName = "User One" };
                var result = await userManager.CreateAsync(user1, "User@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user1, "User");
                }
            }
        }
    }
}
