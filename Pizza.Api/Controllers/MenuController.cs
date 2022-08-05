using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Mapping.Entity.Item;
using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Repositories;
using Pizza.Domain.Entity;
using Pizza.Persistent.EntityTypeContext;
using Pizza.Persistent.Repositories;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IContext _context;
        private IMapper _mapper;
        private ItemRepository _itemRepository;

        public MenuController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _itemRepository = new ItemRepository(_context, _mapper);
        }

        [HttpGet]
        public async Task<ICollection<GetItemMenu>> GetAllFood() => await _itemRepository.GetMenu();

    }
}
