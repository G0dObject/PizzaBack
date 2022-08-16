namespace Pizza.Domain.Entity
{
	public class Size : EntityBase
	{
		public string? SizeName { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
