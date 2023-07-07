using gamezone_api.Models;

namespace gamezone_api.Mappers
{
	public class CartsMapper : ICartsMapper
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

	public interface ICartsMapper
	{
		CartProduct Map(long id, int quantity, ProductCacheEntry productCacheEntry);
    }
}
