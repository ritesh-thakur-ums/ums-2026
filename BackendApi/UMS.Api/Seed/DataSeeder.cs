using Microsoft.EntityFrameworkCore;
using UMS.Api.Data;
using UMS.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace UMS.Api.Seed
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            await context.Database.MigrateAsync();
            await SeedRoles(context);
            await SeedAdmin(context);
        }

        private static async Task SeedRoles(AppDbContext context)
        {
            if (await context.Roles.AnyAsync())
                return;

            var roles = new List<Role>()
            {
                new Role { RoleName = "Admin" },
                new Role { RoleName = "User" }
            };

            await context.Roles.AddRangeAsync(roles);
            await context.SaveChangesAsync();

        }

        private static async Task SeedAdmin(AppDbContext context)
        {
            if (await context.Users.AnyAsync(u => u.Email == "admin@ums.com"))
                return;

            var passwordHasher = new PasswordHasher<User>();

            var admin = new User
            {
                FirstName = "System",
                LastName = "Admin",
                Email = "admin@ums.com",
                IsActive = true,
                CreatedOn = DateTime.UtcNow
            };

            admin.PasswordHash = passwordHasher.HashPassword(admin, "Admin@123");

            await context.Users.AddAsync(admin);
            await context.SaveChangesAsync();

            var adminRole = await context.Roles.FirstAsync(r => r.RoleName == "Admin");

            await context.UserRoles.AddAsync(new UserRole
            {
                UserId = admin.UserId,
                RoleId = adminRole.RoleId
            });

            await context.SaveChangesAsync();
        }
    }
}
