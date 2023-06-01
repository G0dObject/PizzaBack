using System.ComponentModel.DataAnnotations;

namespace Pizza.Domain.Entity
{
	public class Product : EntityBase
	{
		public virtual List<Type>? Types { get; set; }
		public List<Size>? Sizes { get; set; }
		public virtual List<Order>? Order { get; set; }
		public string? Title { get; set; }
		[Range(0, 5)]
		public int? Category { get; set; }
		public string? ImageUrl { get; set; }
		public decimal? Rating { get; set; }
		public virtual decimal? Price { get; set; }

	}
}