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

		public async Task<Models.Order> SubmitOrder(string uuid, Models.Order order)
		{
			var key = new RedisKey($"cart:{uuid}");
			var cartEntries = await _db.HashGetAllAsync(key);
			return null;
		}
	}

	public interface IOrdersRepository
	{
		Task<Models.Order> SubmitOrder(string uuid, Models.Order order);
    }
}

