﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza.Application.Common.Entity.User;
using Pizza.Application.Interfaces.Services;
using Pizza.Domain.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Pizza.Api.Controllers
{
	[Route("api/[Controller]")]
	[ApiController]
	public class TestController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IJwtTokenGenerator _jwtTokenGenerator;
		private readonly RoleManager<Role> _roleManager;

		public TestController(UserManager<User> userManager, IJwtTokenGenerator jwtTokenGenerator,RoleManager<Role> roleManager)
		{
			_userManager = userManager;
			_jwtTokenGenerator = jwtTokenGenerator;
			_roleManager = roleManager;
		}

		[Authorize]
		[HttpGet]		
		public string GetSecret()=> "Ok";
		
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
				{
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));
				}
				JwtSecurityToken? token = _jwtTokenGenerator.GenerateJwtToken(authClaims);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					//expiration = token.ValidTo
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
