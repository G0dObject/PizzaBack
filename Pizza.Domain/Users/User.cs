using Microsoft.AspNetCore.Identity;
using Pizza.Domain.Entity;
using System.Text.Json.Serialization;

namespace Pizza.Domain.Users
{

	public class User : IdentityUser<int>
	{
		public int? CartId { get; set; }
		[JsonIgnore]
		public Cart? Cart { get; set; } = new Cart();
	}
}
