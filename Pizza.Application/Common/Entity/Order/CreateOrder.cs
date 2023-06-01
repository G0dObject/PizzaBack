using System.Text.Json.Serialization;

namespace Pizza.Application.Common.Entity.Order
{
	public class CreateOrder
	{
		public List<int> ProductsId { get; set; }
		public string CustomerNumber { get; set; }
		public Decimal Total { get; set; }
		public int Amount { get; set; }
	}
}
