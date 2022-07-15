using Microsoft.EntityFrameworkCore;
using Pizza.Application.Interfaces;
using Pizza.Persistent.EntityTypeConfiguration;

namespace Pizza.Persistent.EntityTypeContext
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) {}
        public DbSet<Domain.Entity.Food.Pizza>? Pizza { get; set; }

        protected override void OnModelCreating(ModelBuilder option)
        {            
            option.ApplyConfiguration(new PizzaOptionConfiguration());
            base.OnModelCreating(option);
        }
    }
}
