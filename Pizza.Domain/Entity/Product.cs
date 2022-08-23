using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entity
{
	public class Product : EntityBase
	{
		public int? CartId { get; set; }
		public virtual Cart? Cart { get; set; }

		public int? TypeId { get; set; }
		public virtual Type? Type { get; set; }
		public ICollection<Size>? Sizes { get; set; }
		
		[Required]
		public string? Title { get; set; }
		[Required]
		public string? Category { get; set; }
		[Required]
		public string? ImageUrl { get; set; }

		public decimal? Rating { get; set; }
		[Required]
		public virtual decimal? Price { get; set; }

	}
}