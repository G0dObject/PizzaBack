using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Entity.Product;

using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Repositories;
using Pizza.Domain.Entity;

namespace Pizza.Application.Common.Repositories
{
	public class ProductRepository : GenericRepository<Product>, IProductRepository
	{
		private readonly IContext _context;
		private readonly IMapper _mapper;
		public ProductRepository(IContext context, IMapper mapper) : base(context)
		{
			_mapper = mapper;
			_context = context;
		}

		public override async Task Add(Product entity)
		{
			_ = await _context.Products!.AddAsync(entity);
			await Save();
		}
		public override async Task<IEnumerable<Product>> GetAll() => await _context.Products!.ToListAsync();
		public override async Task<Product> GetById(int id) => await _context.Products!.Where(u => u.Id.Equals(id)).FirstAsync();

		public async Task<ICollection<GetProductMenu>> GetMenu() =>
			_mapper.Map<List<GetProductMenu>>(await _context.Products!.Include(d => d.Sizes).ToListAsync());
		

		public override async Task Remove(Product entity)
		{
			_ = _context.Products!.Remove(entity);
			await Save(); 
		}

		public async Task RemoveAll()
		{
			_context.Products!.RemoveRange(_context.Products);
			await Save();
		}
	}
}
