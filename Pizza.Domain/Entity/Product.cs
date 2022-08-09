using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entity
{
    public class Product : EntityBase
    {
        public int? CartId { get; set; }
        public virtual Cart? Cart { get; set; }
        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Type { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        public string? ImageUrl { get; set; }
        public decimal? Rating { get; set; }

        [Required]
        public virtual decimal? Price { get; set; }

        //public string? Size { get; set; }
    }
}