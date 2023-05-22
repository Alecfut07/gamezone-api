
using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace gamezone_api.Services
{
    public class CartService : BaseService, ICartsService
    {
        private CartsRepository _cartsRepository;

        public CartService(ILogger logger, CartsRepository cartsRepository)
            : base(logger)
        {
            _cartsRepository = cartsRepository;
        }

        public async Task<CartResponse> GetCart(string uuid)
        {
            try
            {
                return await _cartsRepository.GetCart(uuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task AddItemToCart(string uuid, CartRequest cartRequest)
        {
            try
            {
                await _cartsRepository.AddItemToCart(uuid, cartRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task UpdateQuantity(string uuid, CartRequest cartRequest)
        {
            try
            {
                await _cartsRepository.UpdateQuantity(uuid, cartRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task RemoveAllItemsInCart(string uuid)
        {
            try
            {
                await _cartsRepository.RemoveAllItemsInCart(uuid);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task RemoveItemInCart(string uuid, CartRequest cartRequest)
        {
            try
            {
                await _cartsRepository.RemoveItemInCart(uuid, cartRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }
    }

    public interface ICartsService
    {
        Task<CartResponse> GetCart(string uuid);

        Task AddItemToCart(string uuid, CartRequest cartRequest);

        Task UpdateQuantity(string uuid, CartRequest cartRequest);

        Task RemoveAllItemsInCart(string uuid);

        Task RemoveItemInCart(string uuid, CartRequest cartRequest);
    }
}

