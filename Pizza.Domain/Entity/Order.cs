using Pizza.Domain.Users;
using System.Text.Json.Serialization;

namespace Pizza.Domain.Entity
{
	public class Order : EntityBase
	{
		public virtual List<Product>? Products { get; set; }
		public string CustomerNumber { get; set; }
		public decimal Total { get; set; }
		public int Amount { get; set; }
	}
}
