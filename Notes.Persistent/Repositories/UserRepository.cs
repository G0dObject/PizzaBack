using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Repositories;
using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Repositories;
using Pizza.Domain.Users;

namespace Pizza.Persistent.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context) : base(context)=> _context = context;

        public override async Task Add(User entity)
        {
            _ = await _context.Users!.AddAsync(entity);
            await Save();
        }
        public override async Task<IEnumerable<User>> GetAll() => await _context.Users!.ToListAsync();
        public override async Task<User> GetById(int id) => await _context.Users!.Where(u => u.Id.Equals(id)).FirstAsync();

        public override async Task Remove(User entity)
        {
            _ = _context.Users!.Remove(entity);
            await Save();
        }
    }
}
