using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using Pizza.Persistent.EntityTypeConfiguration;
using Pizza.Domain.Users;
namespace Pizza.Persistent.EntityTypeContext
{
    public class Context : IdentityDbContext<User>, IContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public override DbSet<User>? Users{ get; set; }
        public override DbSet<IdentityUserRole<string>>? UserRoles { get; set; }
        public override DbSet<IdentityUserToken<string>>? UserTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder option)
        {
            _ = option.ApplyConfiguration(new UserOptionConfiguration());
            _ = option.ApplyConfiguration(new ItemOptionConfiguration());
            _ = option.ApplyConfiguration(new CartOptionConfiguration());
            _ = option.ApplyConfiguration(new UserRoleOptionConfiguration());
            _ = option.ApplyConfiguration(new UserTokensOptionConfiguration());
            
            base.OnModelCreating(option);
        }
    }
}
