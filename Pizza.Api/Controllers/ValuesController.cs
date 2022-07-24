using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Interfaces;
using Pizza.Persistent.EntityTypeContext;

namespace Pizza.Api.Controllers
{
    [AllowAnonymous]

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IContext context;
        public ValuesController(Context _context) => context = _context;

        [HttpPost]
        public async Task<ICollection<int>> Test(List<int> numbers)
        {
            _ = await context.Users.AddAsync(new Domain.Users.User()
            {
                AccessFailedCount = numbers.Count,
                Cart = new Domain.Entity.Cart(),
                Email = "",
                LockoutEnd = DateTimeOffset.Now,
                LockoutEnabled = false
            });            
            _ = await context.SaveChangesAsync(new CancellationToken());
            return numbers;
        }
    }
}
