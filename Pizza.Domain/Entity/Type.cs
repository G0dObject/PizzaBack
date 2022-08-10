using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entity
{
    public class Type : EntityBase
    {
        public string? TypeName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
