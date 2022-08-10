using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class TypeOptionConfiguration : IEntityTypeConfiguration<Domain.Entity.Type>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Type> builder)
        {
            _ = builder.HasKey(t => t.Id);
            
            _ = builder.HasMany(t => t.Products);
        }
    }
}
