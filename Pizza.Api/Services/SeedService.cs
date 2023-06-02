using Microsoft.AspNetCore.Identity;
using Pizza.Domain.Users;

namespace Pizza.Api.Services
{
	public class SeedService : IDisposable
	{
		private readonly UserManager<User> _userManager;
		public SeedService(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public void Dispose()
		{

		}

		public async Task Seed()
		{
			string login = "Admin123";
			string password = "Admin321";
			User user = new()
			{
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = login
			};
			IdentityResult result = await _userManager.CreateAsync(user, password);
		}
	}
}
