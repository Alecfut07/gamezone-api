using System;
using StackExchange.Redis;
using gamezone_api.Models;

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

		public async Task<Models.Order> SaveNewOrder(Models.Order order)
		{
			return null;
		}
	}

	public interface IOrdersRepository
	{
		Task<Models.Order> SaveNewOrder(Models.Order order);
    }
}

