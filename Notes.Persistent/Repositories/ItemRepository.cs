using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Mapping.Entity.Item;
using Pizza.Application.Common.Repositories;
using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Repositories;
using Pizza.Domain.Entity;

namespace Pizza.Persistent.Repositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository 
    {
        IContext _context;
        IMapper _mapper;
        public ItemRepository(IContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
            _context = context;
        }

        public override async Task Add(Item entity)
        {
            _ = await _context.Items!.AddAsync(entity);
            await Save();
        }
        public override async Task<IEnumerable<Item>> GetAll() => await _context.Items!.ToListAsync();
        public override async Task<Item> GetById(int id) => await _context.Items!.Where(u => u.Id.Equals(id)).FirstAsync();

        public async Task<ICollection<GetItemMenu>> GetMenu()
        {
            return _mapper.Map<List<GetItemMenu>>(await _context.Items!.ToListAsync());
        }

        public override async Task Remove(Item entity)
        {
            _ = _context.Items!.Remove(entity);
            await Save();
        }
    }
}
