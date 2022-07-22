using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Application.Interfaces;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Persistent
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration, bool IsDevelopment = false)
        {
            if (IsDevelopment)
            {
                string? connectionString = configuration.GetConnectionString("MySql");
                _ = services.AddDbContext<Context>(option =>
                {
                    _ = option.UseMySQL(connectionString);
                });
            }
            else
            {
                string? connectionString = configuration.GetConnectionString("SqLite");
                _ = services.AddDbContext<Context>(option =>
                {
                    _ = option.UseSqlite(connectionString);
                });
            }
            _ = services.AddScoped<IContext>(provider =>
               provider.GetService<Context>() ?? new Context(new DbContextOptions<Context>()));
            return services;
        }
    }
}
