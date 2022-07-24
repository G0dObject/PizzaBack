using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class UserRoleOptionConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            _ = builder.HasKey(i => i.UserId);
            _ = builder.Property(x => x.RoleId).HasMaxLength(128);
            _ = builder.Property(x => x.UserId).HasMaxLength(128);
            
        }
    }
}
