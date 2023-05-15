
using System;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace gamezone_api.Services
{
	public class CartService : ICartsService
    {
		private CartsRepository cartsRepository;

		public CartService(CartsRepository cartsRepository) 
		{
			this.cartsRepository = cartsRepository;
		}

		public async Task GetCart(string uuid)
		{
			await cartsRepository.GetCart(uuid);
		}

		public async Task AddItemToCart(string uuid, CartRequest cartRequest)
		{
			await cartsRepository.AddItemToCart(uuid, cartRequest);
		}

		public async Task UpdateQuantity(string uuid, CartRequest cartRequest)
		{
			await cartsRepository.UpdateQuantity(uuid, cartRequest);
		}

		public async Task RemoveItemInCart(string uuid)
		{
			await cartsRepository.RemoveItemInCart(uuid);
		}
	}

	public interface ICartsService
	{
		Task GetCart(string uuid);

		Task AddItemToCart(string uuid, CartRequest cartRequest);

		Task UpdateQuantity(string uuid, CartRequest cartRequest);

		Task RemoveItemInCart(string uuid);
	}
}

