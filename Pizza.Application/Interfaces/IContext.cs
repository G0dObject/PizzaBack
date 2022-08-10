using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entity;
using Pizza.Domain.Users;

namespace Pizza.Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<User>? Users { get; set; }

        public DbSet<IdentityUserRole<int>>? UserRoles { get; set; }
        public DbSet<IdentityUserToken<int>>? UserTokens { get; set; }
        public DbSet<Domain.Entity.Type>? Types { get; set; }
        public DbSet<Size>? Sizes { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
