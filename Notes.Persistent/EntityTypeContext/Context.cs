using Microsoft.EntityFrameworkCore;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using Pizza.Persistent.EntityTypeConfiguration;

namespace Pizza.Persistent.EntityTypeContext
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }
        public DbSet<Item>? Items { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<User>? Users { get; set; }
        protected override void OnModelCreating(ModelBuilder option)
        {
            _ = option.ApplyConfiguration(new UserOptionConfiguration());
            _ = option.ApplyConfiguration(new ItemOptionConfiguration());
            _ = option.ApplyConfiguration(new CartOptionConfiguration());

            base.OnModelCreating(option);
        }
    }
}
