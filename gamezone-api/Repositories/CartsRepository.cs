using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using System.Text.Json;
using gamezone_api.Models;

namespace gamezone_api.Repositories
{
	public class CartsRepository
	{
		private IDatabase _db;
		private GamezoneContext context;
        private ProductsMapper productsMapper;
        private CartsMapper cartsMapper;

        public CartsRepository(GamezoneContext dbContext, IDatabase db, ProductsMapper productsMapper, CartsMapper cartsMapper)
		{
			context = dbContext;
			_db = db;
			this.productsMapper = productsMapper;
			this.cartsMapper = cartsMapper;
		}

		public async Task<CartResponse> GetCart(string uuid)
		{
			var key = new RedisKey($"cart:{uuid}");
			var cart = await _db.HashGetAllAsync(key);

			var products = cart.ToList().ConvertAll((c) => {
				var redisKey = new RedisKey(c.Name);
                var jsonProduct = _db.StringGet(redisKey);
                var productCacheEntry = JsonSerializer.Deserialize<ProductCacheEntry>(jsonProduct.ToString());
				var productId = long.Parse(c.Name.ToString().Split(":").Last());
				var quantity = int.Parse(c.Value);
				return cartsMapper.Map(productId, quantity, productCacheEntry);
            });
			var cartResponse = new CartResponse
			{
				products = products
            };
			return cartResponse;
		}

		public async Task AddItemToCart(string uuid, CartRequest cartRequest)
		{
			var key = new RedisKey($"cart:{uuid}");
			var fields = new HashEntry[] {
				new HashEntry($"product:{cartRequest.ProductId}", cartRequest.Quantity),
			};
			await _db.HashSetAsync(key, fields);

			var product = await context.Products
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
				new HashEntry("product:quantity", cartRequest.Quantity),
			};
            await _db.HashSetAsync(key, fieldQuantity);
        }

		public async Task RemoveItemInCart(string uuid)
		{
			var key = new RedisKey($"cart:{uuid}");
			//HashEntry[] fieldsToRemove = await _db.HashGetAllAsync(key);
			//RedisValue[] fieldsKeysToRemove = await _db.HashKeysAsync(key);
			//await _db.HashDeleteAsync(key, fieldsKeysToRemove);
			await _db.KeyDeleteAsync(key);
		}
	}
}

