using Microsoft.EntityFrameworkCore;
using Pizza.Domain.Entity;

namespace Pizza.Application.Interfaces
{
    public interface IContext
    {      
        public DbSet<Item>? Items { get; set; }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<User>? Users { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
