using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using gamezone_api.Models;

namespace gamezone_api.Repositories
{
	public class CartsRepository : ICartsRepository
	{
		private IDatabase _db;
		private GamezoneContext _context;
        private ICartsMapper _cartsMapper;

        public CartsRepository(IDatabase db, GamezoneContext context, ICartsMapper cartsMapper)
		{
			_db = db;
			_context = context;
			_cartsMapper = cartsMapper;
		}

		public async Task<List<(long, int, ProductCacheEntry)>> GetCart(string uuid)
		{
			var key = new RedisKey($"cart:{uuid}");
			var cartEntries = await _db.HashGetAllAsync(key);
            var tuples = cartEntries.ToList().ConvertAll((c) => {
                var redisKey = new RedisKey(c.Name);
                var jsonProduct = _db.StringGet(redisKey);
                var productId = long.Parse(c.Name.ToString().Split(":").Last());
                var quantity = int.Parse(c.Value);
                var productCacheEntry = JsonSerializer.Deserialize<ProductCacheEntry>(jsonProduct.ToString());
                return (productId, quantity, productCacheEntry);
            });
            return tuples;
		}

		public async Task AddItemToCart(string uuid, CartRequest cartRequest)
		{
			var key = new RedisKey($"cart:{uuid}");
			var fields = new HashEntry[] {
				new HashEntry($"product:{cartRequest.ProductId}", cartRequest.Quantity),
			};
			await _db.HashSetAsync(key, fields);

			var product = await _context.Products
				.Include(p => p.ProductVariants)
				.SingleOrDefaultAsync(p => p.Id == cartRequest.ProductId);

			var productKey = new RedisKey($"product:{cartRequest.ProductId}");
			var productCacheEntry = new ProductCacheEntry
            {
				Name = product.Name,
				Price = (double)product.ProductVariants.First().Price
			};

			var productJson = JsonSerializer.Serialize(productCacheEntry);
            await _db.StringSetAsync(productKey, productJson);
        }


        public async Task UpdateQuantity(string uuid, CartRequest cartRequest)
		{
			var key = new RedisKey($"cart:{uuid}");
			var fieldQuantity = new HashEntry[]
			{
				new HashEntry($"product:{cartRequest.ProductId}", cartRequest.Quantity),
			};
			await _db.HashSetAsync(key, fieldQuantity);
        }

		public async Task RemoveAllItemsInCart(string uuid)
		{
			var key = new RedisKey($"cart:{uuid}");
			//HashEntry[] fieldsToRemove = await _db.HashGetAllAsync(key);
			//RedisValue[] fieldsKeysToRemove = await _db.HashKeysAsync(key);
			//await _db.HashDeleteAsync(key, fieldsKeysToRemove);
			await _db.KeyDeleteAsync(key);
		}

		public async Task RemoveItemInCart(string uuid, CartRequest cartRequest)
		{
			var key = new RedisKey($"cart:{uuid}");
			await _db.HashDeleteAsync(key, $"product:{cartRequest.ProductId}");
		}
    }

	public interface ICartsRepository
	{
		Task<List<(long, int, ProductCacheEntry)>> GetCart(string uuid);

		Task AddItemToCart(string uuid, CartRequest cartRequest);

		Task UpdateQuantity(string uuid, CartRequest cartRequest);

		Task RemoveAllItemsInCart(string uuid);

		Task RemoveItemInCart(string uuid, CartRequest cartRequest);
	}
}

