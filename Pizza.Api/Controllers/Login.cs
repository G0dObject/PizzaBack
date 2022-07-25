using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Pizza.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        [HttpPost]
        public async Task<StatusCodeResult> LogIn()
        {
            return Ok();
        }
    }
}
