using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pizza.Application.Common.Entity.Order;
using Pizza.Application.Interfaces;
using Pizza.Domain.Entity;
using System.Collections.Generic;

namespace Pizza.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private IContext _context; private readonly IMapper _mapper;
		public OrderController(IContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}


		[HttpPost]
		public async Task AddOrder(CreateOrder order)
		{
			List<Product?> products = order.ProductsId.Select(f => _context.Products.FirstOrDefault(f => f.Id == f.Id)).ToList();

			await _context.Orders.AddAsync(new Order() { Products = products, CustomerNumber = order.CustomerNumber, Total = order.Total, Amount = order.Amount });
			await _context.SaveChangesAsync(new CancellationToken());
		}

		[HttpGet]
		public async Task<List<CreateOrder>> GetAll()
		{
			List<Order> temp = _context.Orders.Include(f => f.Products).ToList();

			List<CreateOrder> list = new List<CreateOrder>();
			foreach (Order item in temp)
			{
				list.Add(new CreateOrder() { Total = item.Total, Amount = item.Amount, CustomerNumber = item.CustomerNumber, ProductsId = item.Products.Select(f => f.Id).ToList() });
			}
			return list;



		}
	}
}
