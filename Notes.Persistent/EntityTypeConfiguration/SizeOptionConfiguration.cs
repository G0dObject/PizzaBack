using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.EntityTypeConfiguration
{
	public class SizeOptionConfiguration : IEntityTypeConfiguration<Size>
	{
		public void Configure(EntityTypeBuilder<Size> builder)
		{
			_ = builder.HasKey(s => s.Id);
		}
	}
}
