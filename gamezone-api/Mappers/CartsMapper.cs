using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class CartsMapper
	{
		public CartProduct Map(long id, int quantity, ProductCacheEntry productCacheEntry)
		{
			return new CartProduct
            {
				ProductId = id,
				Name = productCacheEntry.Name,
				Price = productCacheEntry.Price,
				Quantity = quantity
			};
		}
	}
}
