using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Interfaces;
using Pizza.Persistent.EntityTypeContext;
using Pizza.Persistent.Repositories;

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
        public async Task<JsonResult> GetAllFood() => new JsonResult(await _itemRepository.GetMenu());
    }
}
