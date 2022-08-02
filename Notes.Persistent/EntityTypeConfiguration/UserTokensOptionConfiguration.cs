﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class UserTokensOptionConfiguration : IEntityTypeConfiguration<IdentityUserToken<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<int>> builder)
        {
            _ = builder.HasKey(i => i.UserId);
        }
    }
}