using System.ComponentModel.DataAnnotations;

namespace Pizza.Application.Common.Entity.Product
{
	public class GetProductMenu
	{
		public int Id { get; set; }
		public string? Title { get; set; }
		public virtual decimal? Price { get; set; }
		public string? ImageUrl { get; set; }
		public List<int>? Sizes { get; set; }
		public List<string>? Types { get; set; }
		public decimal? Rating { get; set; }
	}
}
