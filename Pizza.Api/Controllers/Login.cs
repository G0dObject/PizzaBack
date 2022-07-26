using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Mapping.Entity;
using Pizza.Application.Interfaces;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public Login(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<StatusCodeResult> Register(CreateUser user)
        {
            var tempuser = _mapper.Map<User>(user);
            tempuser.Cart = new Domain.Entity.Cart();
            _ = await _context.Users.AddAsync(tempuser);            
            _ = await _context.SaveChangesAsync(new CancellationToken());
            return Ok();
        }
    }
}
