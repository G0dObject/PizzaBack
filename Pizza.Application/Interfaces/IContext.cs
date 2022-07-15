using Microsoft.EntityFrameworkCore;

namespace Pizza.Application.Interfaces
{
    public interface IContext
    {
        public DbSet<Domain.Entity.Food.Pizza>? Pizza { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
