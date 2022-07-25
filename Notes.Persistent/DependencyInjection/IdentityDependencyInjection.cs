using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Persistent.DependencyInjection
{
    public static class IdentityDependencyInjection
    {
        public static IServiceCollection AddIdentityDependency(this IServiceCollection services)
        {
            IdentityBuilder? builder = services.AddIdentityCore<User>(
                option =>
                {
                    option.Stores.MaxLengthForKeys = 128;
                    option.User.RequireUniqueEmail = true;

                    option.SignIn.RequireConfirmedPhoneNumber = false;
                    option.SignIn.RequireConfirmedEmail = false;

                    option.Password.RequireDigit = false;
                    option.SignIn.RequireConfirmedAccount = true;                                                          
                });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), services);
            _ = builder.AddEntityFrameworkStores<Context>();
            return services;
        }
    }
}
