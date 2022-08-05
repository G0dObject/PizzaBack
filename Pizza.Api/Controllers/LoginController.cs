using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Mapping.Entity.User;
using Pizza.Application.Interfaces;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeContext;
using Pizza.Persistent.Repositories;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        private readonly UserRepository _userRepository;

        public LoginController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = new UserRepository(_context);
        }

        [HttpPost]
        public async Task<StatusCodeResult> Register(CreateUser user)
        {
            await _userRepository.Add(_mapper.Map<User>(user));
            return Ok();
        }
    }
}
