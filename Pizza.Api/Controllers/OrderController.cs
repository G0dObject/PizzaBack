using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Entity.Order;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;

namespace Pizza.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IContext _context;
		public OrderController(IContext context)
		{
			_context = context;
		}


		[HttpPost]
		public async Task AddOrder(CreateOrder order)
		{
			List<Product?> products = order.ProductsId.Select(f => _context.Products.FirstOrDefault(f => f.Id == f.Id)).ToList();

			await _context.Orders.AddAsync(new Order() { Products = products, CustomerNumber = order.CustomerNumber, Total = order.Total, Amount = order.Amount });
			await _context.SaveChangesAsync(new CancellationToken());
		}

		[HttpGet]
		public async Task<List<Order>> GetAll()
		{
			return _context.Orders.ToList();
		}
	}
}
