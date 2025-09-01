using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RoleAuthDemo.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<RoleAuthDemo.Models.ApplicationUser>>();

            string[] roles = new[] { "Admin", "Manager" };

            foreach (var r in roles)
            {
                if (!await roleManager.RoleExistsAsync(r))
                    await roleManager.CreateAsync(new IdentityRole(r));
            }


            var adminEmail = "admin@local";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new RoleAuthDemo.Models.ApplicationUser
                {
                    UserName = "admin",
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                var res = await userManager.CreateAsync(adminUser, "Admin@123"); // sample password
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }


            var managerEmail = "manager1@local";
            var managerUser = await userManager.FindByEmailAsync(managerEmail);
            if (managerUser == null)
            {
                managerUser = new RoleAuthDemo.Models.ApplicationUser
                {
                    UserName = "manager1",
                    Email = managerEmail,
                    EmailConfirmed = true
                };
                var res = await userManager.CreateAsync(managerUser, "Manager@123");
                if (res.Succeeded)
                {
                    await userManager.AddToRoleAsync(managerUser, "Manager");
                }
            }
        }
    }
}
