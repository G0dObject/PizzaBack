using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.EntityTypeConfiguration
{
	public class OrderOptionConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			_ = builder.HasKey(c => c.Id);
			_ = builder.HasMany(t => t.Products).WithMany(f => f.Order);
		}
	}
}
