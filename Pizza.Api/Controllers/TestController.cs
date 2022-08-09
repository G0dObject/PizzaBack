using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Mapping.Entity.Product;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
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
        private readonly ProductRepository _itemRepository;

        public TestController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _itemRepository = new ProductRepository(_context, _mapper);
        }
        [HttpPost]
        public async Task<StatusCodeResult> AddItem(Product product)
        {
            await _itemRepository.Add(product);
            return Ok();
        }
        [HttpGet]
        public async Task<StatusCodeResult> DeleteAll()
        {
            await _itemRepository.RemoveAll();
            return Ok();
        }
    }
}
