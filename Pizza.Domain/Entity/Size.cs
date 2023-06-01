namespace Pizza.Domain.Entity
{
	public class Size : EntityBase
	{
		public int SizeName { get; set; }
		public int ProductId { get; set; }
		public virtual Product? Product { get; set; }

	}
}
