using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Entity.Product;
using Pizza.Application.Common.Repositories;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using Pizza.Persistent.EntityTypeContext;
using System.ComponentModel;

namespace Pizza.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuController : ControllerBase
	{
		private readonly IContext _context;
		private readonly IMapper _mapper;
		private readonly ProductRepository _itemRepository;

		public MenuController(Context context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
			_itemRepository = new ProductRepository(_context, _mapper);
		}
		[HttpGet]
		[Route("Items")]
		public List<GetProductMenu> GetMenuByCategory(int category, string sortBy, string order, int page, int limits)
		{
			Func<Product, object> orderByFunc = new Func<Product, object>(f => f.Id);

			orderByFunc = sortBy switch
			{
				"title" => item => item.Title,
				_ => item => item.Id
			};

			Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Product, object> _First = _context.Products.Include(f => f.Sizes).Include(f => f.Types);
			IOrderedEnumerable<Product> _Sort = _First.OrderBy(orderByFunc);
			IEnumerable<Product> _Category = category == 0 ? _Sort : _Sort.Where(w => w.Category == category);

			return _mapper.Map<List<GetProductMenu>>(_Category.ToList());
		}
		//[Authorize]
		[HttpPost]
		public async Task AddFood(CreateProduct product)
		{
			await _itemRepository.Add(_mapper.Map<Product>(product));
		}

		[HttpGet]
		public List<GetProductMenu> GetAllFood()
		{
			List<Product> source = _context.Products.Include(f => f.Sizes).Include(f => f.Types).ToList();
			return _mapper.Map<List<GetProductMenu>>(source);
		}
	}
}
