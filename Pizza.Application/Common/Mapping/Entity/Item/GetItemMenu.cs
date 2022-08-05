using System.ComponentModel.DataAnnotations;

namespace Pizza.Application.Common.Mapping.Entity.Item
{
    public class GetItemMenu
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Rating { get; set; }
    }
}
