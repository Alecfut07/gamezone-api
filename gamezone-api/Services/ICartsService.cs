using System;
using gamezone_api.Networking;

namespace gamezone_api.Services
{
	public interface ICartsService
	{
        Task<CartResponse> GetCart(string uuid);

        Task AddItemToCart(string uuid, CartRequest cartRequest);

        Task UpdateQuantity(string uuid, CartRequest cartRequest);

        Task RemoveAllItemsInCart(string uuid);

        Task RemoveItemInCart(string uuid, CartRequest cartRequest);
    }
}

