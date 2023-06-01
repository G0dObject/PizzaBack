using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Entity.Product;
using Pizza.Application.Common.Repositories;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using Pizza.Persistent.EntityTypeContext;


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
		public List<Product> GetMenuByCategory(int category, string sortBy, string order, int page, int limits)
		{
			Func<Product, object> orderByFunc = new Func<Product, object>(f => f.Id);

			orderByFunc = sortBy switch
			{
				"title" => item => item.Title,
				_ => item => item.Id
			};

			IQueryable<Product> _First = _context.Products.AsQueryable();
			IOrderedEnumerable<Product> _Sort = _First.OrderBy(orderByFunc);
			IEnumerable<Product> _Category = category == 0 ? _Sort : _Sort.Where(w => w.Category == category);

			return _Category.ToList();

		}
		//[Authorize]
		[HttpPost]
		public async Task AddFood(CreateProduct product)
		{
			await _itemRepository.Add(_mapper.Map<Product>(product));
		}

		[HttpGet]
		public async Task<JsonResult> GetAllFood()
		{
			return new JsonResult(await _itemRepository.GetMenu());
		}
	}
}
