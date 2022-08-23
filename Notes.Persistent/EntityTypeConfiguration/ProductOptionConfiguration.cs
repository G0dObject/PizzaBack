using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.EntityTypeConfiguration
{
	public class ProductOptionConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			_ = builder.HasKey(p => p.Id);
			_ = builder.Property(p => p.Rating);
			_ = builder.Property(p => p.Price);
			_ = builder.Property(p => p.ImageUrl);
			
			
		}
	}
}
