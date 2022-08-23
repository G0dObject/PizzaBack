namespace Pizza.Domain.Entity
{
	public class Size : EntityBase
	{
		public string? SizeName { get; set; }
		public int? ProductId { get; set; }
		public virtual Product? Product { get; set; }

	}
}
