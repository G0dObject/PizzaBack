using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pizza.Domain.Entity
{
    public class Item : EntityBase
    {    
        public int? CartId { get; set; } 
        public virtual Cart? Cart { get; set; }

        public virtual string? Type { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public decimal? Rating { get; set; }

        [Required]
        public virtual decimal? Price { get; set; }

        
        
    }
}