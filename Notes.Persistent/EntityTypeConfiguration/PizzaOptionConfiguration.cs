using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class PizzaOptionConfiguration : IEntityTypeConfiguration<Pizza.Domain.Entity.Food.Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza.Domain.Entity.Food.Pizza> builder)
        {
            builder.HasKey(p => p.Id);
        }
    }
}
