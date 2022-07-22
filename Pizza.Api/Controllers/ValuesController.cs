using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
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
            _ = await context.Items.AddAsync(
                new Item()
                {
                    Cart = new Cart(),
                    CartId = 0,
                    Id = 0,
                    ImageUrl = "",
                    Price = 0,
                    Rating = 0,
                    Title = "",
                    Type = ""
                });

            await context.SaveChangesAsync(new CancellationToken());
            return numbers;
        }
    }
}
