using Blog.Domain.Entity;
using Blog.Domain.Enum;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Seed
{
    public static class DbInitializer
    {
        public static void Initialize(BlogDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Users.Any(u => u.Role == Roles.Admin))
            {
                var admin = new User
                {
                    Name = "Admin",
                    Email = "admin@blog.com",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"), // senha inicial
                    Role = Roles.Admin
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
        }
    }
}
