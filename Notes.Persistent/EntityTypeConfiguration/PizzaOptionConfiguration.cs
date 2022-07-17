using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class PizzaOptionConfiguration : IEntityTypeConfiguration<Domain.Entity.Food.Pizza>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Food.Pizza> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Rating);
            builder.Property(p => p.Price);
            builder.Property(p => p.Type);
            builder.Property(p => p.ImageUrl);
        }
    }
}
