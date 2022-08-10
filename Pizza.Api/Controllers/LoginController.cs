using AutoMapper;
using Microsoft.AspNetCore.Identity;
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

        //private readonly UserManager<User> _userManager;
        //private readonly SignInManager<User> _signInManager;


        public LoginController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userRepository = new UserRepository(_context);
        }

        [HttpPost]
        public async Task<StatusCodeResult> Register(CreateUser cuser)
        {
            await _userRepository.Add(_mapper.Map<User>(cuser));

            return Ok();
        }
    }
}
