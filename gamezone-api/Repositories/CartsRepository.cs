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

		public CartsRepository(GamezoneContext dbContext, IDatabase db, ProductsMapper productsMapper)
		{
			context = dbContext;
			_db = db;
			this.productsMapper = productsMapper;
		}

		public async Task GetCart(string uuid)
		{
			var key = new RedisKey($"cart:{uuid}");
			var cart = await _db.HashGetAllAsync(key);

			var productEntries = cart.ToList().ConvertAll((c) => new RedisKey(c.Name)).ToArray();
			var jsonProducts = _db.StringGet(productEntries);

			//JsonSerializer.Deserialize<Product>(product.ToString());
			var products = jsonProducts.ToList().ConvertAll((p) => JsonSerializer.Deserialize<Product>(p.ToString()));
			//var cartResponse = new
			//{
			//	cart_id = key,
			//	product_id = cart[0].Key,
			//	quantity = cart[0].Value,
			//	products = new[]
			//	{
			//		new
			//		{

			//		}
			//	}
			//};
			Console.WriteLine();
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

			var anonymousProduct = new
			{
				Name = product.Name,
				Price = (double)product.ProductVariants.First().Price
			};

			var productJson = JsonSerializer.Serialize(anonymousProduct);
            await _db.StringSetAsync(productKey, productJson);
			//var productFields = new HashEntry[] {
			//	new HashEntry($"product:{cartRequest.ProductId}", "JSON")
			//};
            //await _db.HashSetAsync(key, productFields);
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

