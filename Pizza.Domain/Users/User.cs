using Microsoft.AspNetCore.Identity;
using Pizza.Domain.Entity;

namespace Pizza.Domain.Users
{
    public class User : IdentityUser<int>
    {      
        public int? CartId { get; set; }
        public Cart? Cart { get; set; } = new Cart();
    }
}
