using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Interfaces;
using Pizza.Persistent.EntityTypeContext;
using Pizza.Persistent.Repositories;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly ItemRepository _itemRepository;

        public TestController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _itemRepository = new ItemRepository(_context, _mapper);
        }
        [HttpGet]
        public void Test()
        {
        }
    }
}
