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

		[Authorize]
		[HttpPost]
		public async Task AddFood(CreateProduct product)
		{
			await _itemRepository.Add(_mapper.Map<Product>(product));
		}
		
		[HttpGet]
		public async Task<JsonResult> GetAllFood() => new JsonResult(await _itemRepository.GetMenu());
	}
}
