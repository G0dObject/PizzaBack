using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entity
{
	public class Product : EntityBase
	{
		public int? CartId { get; set; }
		public virtual Cart? Cart { get; set; }

		public virtual ICollection<Type?> Types { get; set; }

		public ICollection<Size>? Sizes { get; set; }

		[Required]
		public string? Title { get; set; }
		[Required]

		[Range(0, 5)]
		public int? Category { get; set; }
		[Required]
		public string? ImageUrl { get; set; }

		public decimal? Rating { get; set; }
		[Required]
		public virtual decimal? Price { get; set; }

	}
}