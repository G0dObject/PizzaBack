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
using System.Linq;

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
		public List<GetProductMenu> GetMenuByCategory(int category, string sortBy, string order, int page, int limit)
		{
			Func<Product, object> orderByFunc = new Func<Product, object>(f => f.Id);

			orderByFunc = sortBy switch
			{
				"price" => item => item.Price,
				"title" => item => item.Title,
				"rating" => item => item.Rating,

				_ => item => item.Id
			};

			List<Product> _First = _context.Products.Include(f => f.Sizes).Include(f => f.Types).ToList();
			IOrderedEnumerable<Product> _Sort = _First.OrderBy(orderByFunc);
			IEnumerable<Product> _Category = category == 0 ? _Sort : _Sort.Where(w => w.Category == category);
			IEnumerable<Product> _Page = page <= 1 ? _Category : _Category.Skip((page - 1) * limit);
			List<Product> limits = _Page.Take(limit).ToList();
			IEnumerable<Product> ord = order == "asc" ? limits : limits;//_Category.Reverse().ToList();


			List<Product> List = ord.ToList();
			List<GetProductMenu> mapped = _mapper.Map<List<GetProductMenu>>(List.ToList());

			for (int i = 0; i < mapped.Count; i++)
			{
				mapped[i].Id = List[i].Id;
				mapped[i].Sizes = List[i].Sizes.Select(f => f.SizeName).ToList();
			}
			return mapped;
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
			List<GetProductMenu> mapped = _mapper.Map<List<GetProductMenu>>(source);
			for (int i = 0; i < source.Count; i++)
			{
				mapped[i].Id = source[i].Id;
				mapped[i].Sizes = source[i].Sizes.Select(f => f.SizeName).ToList();
			}
			return mapped;
		}
		[HttpDelete]
		public void DeleteById([FromQuery] int id)
		{
			_context.Products.Remove(_context.Products.First(f => f.Id == id));
			_context.SaveChangesAsync(new CancellationToken());
		}
		[HttpGet]
		[Route("lastid")]
		public int GetLastId()
		{
			if (_context.Products.Count() == 0)
			{
				return 0;
			}
			return _context.Products.Max(f => f.Id);
		}
	}
}
