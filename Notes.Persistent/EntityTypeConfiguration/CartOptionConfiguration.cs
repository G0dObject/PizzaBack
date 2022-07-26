using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class CartOptionConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            _ = builder.HasKey(c => c.Id);
            _ = builder.HasMany(c => c.Items);            
        }
    }
}
