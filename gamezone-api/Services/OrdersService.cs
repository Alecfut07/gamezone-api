using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class OrdersService : BaseService, IOrdersService
	{
		private CartsRepository _cartsRepository;
		private IOrdersRepository _ordersRepository;
		private CartsMapper _cartsMapper;
		private OrdersMapper _ordersMapper;

		public OrdersService(ILogger logger, IOrdersRepository ordersRepository, CartsRepository cartsRepository, OrdersMapper ordersMapper, CartsMapper cartsMapper)
			: base(logger)
		{
			_ordersRepository = ordersRepository;
			_cartsRepository = cartsRepository;
			_cartsMapper = cartsMapper;
            _ordersMapper = ordersMapper;
        }

		public async Task<OrderResponse?> SubmitOrder(string uuid, long userId, OrderRequest orderRequest, long subtotal, long tax, long amount)
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
                var newOrder = _ordersMapper.Map(userId, cartProducts, orderRequest, subtotal, tax, amount);
				Console.WriteLine();
				//var order = await _ordersRepository.SubmitOrder(cartProducts, newOrder);

				return null;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, null);
				throw;
			}
		}
    }

	public interface IOrdersService
	{
		Task<OrderResponse?> SubmitOrder(string uuid, long userId, OrderRequest orderRequest, long subtotal, long tax, long amount);
    }
}

