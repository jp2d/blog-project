using Blog.Domain.Interfaces;
using Blog.Infrastructure.Context;
using Blog.Infrastructure.Repository;
using Blog.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Applications
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // EF Core
            services.AddDbContext<BlogDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));

            // Repositórios
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Aqui você pode registrar também serviços de aplicação
            // services.AddScoped<IPostService, PostService>();

            return services;
        }

        public static void InitializeDatabase(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<BlogDbContext>();
            DbInitializer.Initialize(context);
        }
    }
}
