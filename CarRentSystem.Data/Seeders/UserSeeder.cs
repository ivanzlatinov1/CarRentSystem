using CarRentSystem.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CarRentSystem.Data.Seeders
{
    public static class UserSeeder
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<User> userManager)
        {
            // Seeding the admin
            var adminUser = new User
            {
                UserName = "admin_user",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                FirstName = "Admin",
                LastName = "User",
                EGN = "0000000000",
                PhoneNumber = "1234567890",
                ImageUrl = @"https://t3.ftcdn.net/jpg/05/87/76/66/360_F_587766653_PkBNyGx7mQh9l1XXPtCAq1lBgOsLl6xH.jpg"
            };

            string adminPassword = "Admin#123";
            await SeedUser(adminUser, adminPassword, "Admin", userManager);

            // Seeding a regular user
            var regularUser = new User()
            {
                UserName = "user_default",
                Email = "user@user.user.com",
                EmailConfirmed = true,
                FirstName = "Test",
                LastName = "User",
                EGN = "0000000000",
                PhoneNumber = "1234567890",
                ImageUrl = @"https://t3.ftcdn.net/jpg/05/87/76/66/360_F_587766653_PkBNyGx7mQh9l1XXPtCAq1lBgOsLl6xH.jpg"
            };
            string regularPassword = "User#123";
            await SeedUser(regularUser, regularPassword, "User", userManager);
        }

        private static async Task SeedUser(User user, string password, string roleName,
            UserManager<User> userManager)
        {
            User? userInfo = await userManager.FindByEmailAsync(user.Email);
            if (userInfo == null)
            {
                var created = await userManager.CreateAsync(user, password);
                if (created.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = ["Admin", "User"];
            foreach (var role in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
    }
}
