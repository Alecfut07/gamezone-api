
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

		public async Task AddItemToCart(string uuid, CartRequest cartRequest)
		{
			await cartsRepository.AddItemToCart(uuid, cartRequest);
		}
	}

	public interface ICartsService
	{
		Task AddItemToCart(string uuid, CartRequest cartRequest); 
	}
}

