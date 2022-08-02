using System.ComponentModel.DataAnnotations.Schema;
using Pizza.Domain.Users;
namespace Pizza.Domain.Entity
{
    public class Cart : EntityBase
    {
        public ICollection<Item>? Items { get; set; }
    
        public User? User { get; set; }
    }
}
