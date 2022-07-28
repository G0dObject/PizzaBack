using Pizza.Application.Common.Repositories;
using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Repositories;
using Pizza.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace Pizza.Persistent.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly IContext _context;

        public UserRepository(IContext context) : base(context)
        {
            _context = context;
        }
        public override async Task Add(User entity)
        {
            _ = await _context.Users.AddAsync(entity);
            _ = await _context.SaveChangesAsync(new CancellationToken());
        }
        public override async Task<IEnumerable<User>> GetAll() => await _context.Users.ToListAsync();

        public override async Task<User> GetById(int id) => await _context.Users.Where(u => u.Id.Equals(id)).FirstOrDefaultAsync();

        public override async Task Remove(User entity)
        {
            if (entity!=null)
            {
                _context.Users.Remove(entity);
                _ = await _context.SaveChangesAsync(new CancellationToken());
            }            
        }
    }
}
