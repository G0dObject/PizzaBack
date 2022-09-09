using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Entity.User;
using Pizza.Application.Interfaces;
using Pizza.Application.Interfaces.Services;
using Pizza.Domain.Users;
using Pizza.Persistent.EntityTypeContext;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pizza.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly IContext _context;
		private readonly IMapper _mapper;

		private readonly UserManager<User> _userManager;
		private readonly RoleManager<Role> _roleManager;
		private readonly SignInManager<User> _signInManager; private readonly IJwtTokenGenerator _jwtTokenGenerator;

		public LoginController(Context context, IMapper mapper,
			UserManager<User> userManager, RoleManager<Role> rolemanager, IJwtTokenGenerator jwtTokenGenerator, SignInManager<User> signInManager)
		{
			_context = context;
			_mapper = mapper;
			_userManager = userManager;
			_roleManager = rolemanager;
			_signInManager = signInManager;
			_jwtTokenGenerator = jwtTokenGenerator;
		}

		[Authorize]
		[HttpGet]
		public string GetSecret() => "Secret Data";

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] CreateUser model)
		{
			User? user = await _userManager.FindByNameAsync(model.UserName);

			if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
			{
				IList<string> userRoles = await _userManager.GetRolesAsync(user);

				List<Claim> authClaims = new()
				{
					new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
				};

				foreach (string? userRole in userRoles)
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));

				JwtSecurityToken? token = _jwtTokenGenerator.GenerateJwtToken(authClaims);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
				});
			}
			return Unauthorized();
		}
		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register(CreateUser model)
		{
			User userExists = await _userManager.FindByNameAsync(model.UserName);
			if (userExists != null)
				return StatusCode(StatusCodes.Status409Conflict, "Alredy exist");

			User user = new()
			{
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.UserName
			};
			IdentityResult result = await _userManager.CreateAsync(user, model.Password);
			return !result.Succeeded
				? StatusCode(StatusCodes.Status400BadRequest, "Create Failed")
				: Ok("User created successfully!");
		}
	}
}
