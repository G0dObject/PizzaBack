using Microsoft.AspNetCore.Identity;
using Pizza.Domain.Entity;

namespace Pizza.Domain.Users
{
    public class User : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        public string? Nick { get; set; }
        public int? CartId { get; set; }
        public Cart? Cart { get; set; }
    }
}
