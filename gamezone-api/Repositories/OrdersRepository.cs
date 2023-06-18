using System;
using StackExchange.Redis;
using gamezone_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class OrdersRepository : IOrdersRepository
    {
		private IDatabase _db;
		private GamezoneContext _context;

		public OrdersRepository(IDatabase db, GamezoneContext context)
		{
			_db = db;
			_context = context;
		}

		public async Task<Models.Order> SubmitOrder(Models.Order order)
		{
			//var key = new RedisKey($"cart:{uuid}");
			//var cartEntries = await _db.HashGetAllAsync(key);
			order.CreateDate = DateTime.UtcNow;

			await _context.Orders.AddAsync(order);
			await _context.SaveChangesAsync();

			var newOrder = await _context.Orders
				.Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
				.Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
				.Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
				.SingleAsync(o => o.Id == order.Id);

			return newOrder;
		}
	}

	public interface IOrdersRepository
	{
		Task<Models.Order> SubmitOrder(Models.Order order);
    }
}

