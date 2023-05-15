using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace gamezone_api.Repositories
{
	public class CartsRepository
	{
		private IDatabase _db;
		private GamezoneContext context;
		private ProductsMapper productsMapper;

		public CartsRepository(GamezoneContext dbContext, IDatabase db, ProductsMapper productsMapper)
		{
			context = dbContext;
			_db = db;
			this.productsMapper = productsMapper;
		}

		public async Task AddItemToCart(string uuid, CartRequest cartRequest)
		{
			var product = await context.Products
				.Include(p => p.ProductVariants)
				.SingleOrDefaultAsync(p => p.Id == cartRequest.ProductId);

			var key = new RedisKey($"cart:{uuid}");
			var fields = new HashEntry[] {
                new HashEntry("product:id", cartRequest.ProductId),
                new HashEntry("product:name", product.Name),
                new HashEntry("product:price", (double)product.ProductVariants.First().Price),
                new HashEntry("product:quantity", cartRequest.Quantity)
            };
			await _db.HashSetAsync(key, fields);
		}
	}
}

