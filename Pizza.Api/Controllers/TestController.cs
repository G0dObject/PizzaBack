using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Mapping.Entity;
using Pizza.Application.Interfaces;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Api.Controllers
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IContext _context;
        private readonly IMapper _mapper;
        public TestController(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ICollection<int>> Test(List<int> numbers)
        {
            _ = _mapper.Map<User>(new CreateUser() { Email = "123", Password = "123", UserName = "123" });


            _ = await _context.Users.AddAsync(new User()
            {
                AccessFailedCount = numbers.Count,
                Cart = new Domain.Entity.Cart(),
                Email = "gmail",
                EmailConfirmed = false,
                ConcurrencyStamp = "1",

                UserName = "Steave",
                PasswordHash = "Passoword".GetHashCode().ToString(),

            });
            _ = await _context.SaveChangesAsync(new CancellationToken());
            return numbers;
        }
    }
}
