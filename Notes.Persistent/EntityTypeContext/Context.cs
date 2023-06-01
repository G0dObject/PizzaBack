using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeConfiguration;
namespace Pizza.Persistent.EntityTypeContext
{
	public class Context : IdentityDbContext<User, Role, int>, IContext
	{
		public Context(DbContextOptions<Context> contextOptions) : base(contextOptions) { }
		public DbSet<Product>? Products { get; set; }
		public DbSet<Order>? Orders { get; set; }
		public override DbSet<User>? Users { get; set; }
		public DbSet<Domain.Entity.Type>? Types { get; set; }
		public DbSet<Size>? Sizes { get; set; }


		protected override void OnModelCreating(ModelBuilder option)
		{
			_ = option.ApplyConfiguration(new UserOptionConfiguration());
			_ = option.ApplyConfiguration(new ProductOptionConfiguration());
			_ = option.ApplyConfiguration(new OrderOptionConfiguration());
			_ = option.ApplyConfiguration(new UserRoleOptionConfiguration());
			_ = option.ApplyConfiguration(new UserTokensOptionConfiguration());
			_ = option.ApplyConfiguration(new TypeOptionConfiguration());
			base.OnModelCreating(option);

		}
	}
}
