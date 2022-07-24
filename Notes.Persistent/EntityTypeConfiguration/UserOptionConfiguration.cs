﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;

namespace Pizza.Persistent.EntityTypeConfiguration
{
    public class UserOptionConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            _ = builder.HasKey(u => u.Id);
            _ = builder.Property(u => u.Nick).HasMaxLength(20);
            _ = builder.Property(u => u.Email);
            _ = builder.Property(u => u.PasswordHash);

            _ = builder.HasOne(u => u.Cart).WithOne(e => e.User);
        }
    }
}
