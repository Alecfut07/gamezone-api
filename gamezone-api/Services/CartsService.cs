﻿
using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace gamezone_api.Services
{
    public class CartsService : BaseService, ICartsService
    {
        private ICartsRepository _cartsRepository;
        private ICartsMapper _cartsMapper;

        public CartsService(ILogger logger, ICartsRepository cartsRepository, ICartsMapper cartsMapper)
            : base(logger)
        {
            _cartsRepository = cartsRepository;
            _cartsMapper = cartsMapper;
        }

        public async Task<CartResponse?> GetCart(string uuid)
        {
            try
            {
                var list = await _cartsRepository.GetCart(uuid);
                var cartProducts = list.ConvertAll((tuple) =>
                {
                    var productId = tuple.Item1;
                    var quantity = tuple.Item2;
                    var productCacheEntry = tuple.Item3;
                    return _cartsMapper.Map(productId, quantity, productCacheEntry);
                });
                var cartResponse = new CartResponse
                {
                    Products = cartProducts
                };
                return cartResponse;
            }
            catch (ArgumentNullException ex)
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
            catch (OperationCanceledException ex)
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
}

