using System.ComponentModel.DataAnnotations.Schema;
using Pizza.Domain.Users;
namespace Pizza.Domain.Entity
{
    public class Cart : EntityBase
    {
        public ICollection<Product>? Products { get; set; }
    
        public User? User { get; set; }
    }
}
