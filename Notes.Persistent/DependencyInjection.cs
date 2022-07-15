using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Pizza.Persistent.EntityTypeContext;
using Pizza.Application.Interfaces;

namespace Pizza.Persistent
{    
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString =  configuration.GetConnectionString("SqLite");
            services.AddDbContext<Context>(option =>
            {
                option.UseSqlite(connectionString);
            });
            services.AddScoped<IContext>(provider =>
               provider.GetService<Context>() ?? new Context(new DbContextOptions<Context>()));
            return services;
        }
    }
}
