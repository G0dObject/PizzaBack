using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class ItemOptionConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            _ = builder.HasKey(i => i.Id);
            _ = builder.Property(i => i.Rating);
            _ = builder.Property(i => i.Price);
            _ = builder.Property(i => i.Type);
            _ = builder.Property(i => i.ImageUrl);            
        }
    }
}
