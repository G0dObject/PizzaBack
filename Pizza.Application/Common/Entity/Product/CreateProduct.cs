using System.ComponentModel.DataAnnotations;

namespace Pizza.Application.Common.Entity.Product
{
	public class CreateProduct
	{
		[Required]
		public string? Title { get; set; }

		[Required]
		public List<string>? Sizes { get; set; }


		public List<string>? Types { get; set; }

		[Required]
		[Range(0, 5)]
		public int? Category { get; set; }

		[Required]
		public string? ImageUrl { get; set; }

		[Required]
		public virtual decimal? Price { get; set; }

		public decimal? Rating { get; set; }
	}
}
