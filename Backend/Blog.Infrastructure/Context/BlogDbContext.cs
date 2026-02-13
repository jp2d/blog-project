using Blog.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entities go here
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
