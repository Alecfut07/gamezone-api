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
		private OrdersMapper _ordersMapper;

		public OrdersService(ILogger logger, IOrdersRepository ordersRepository, CartsRepository cartsRepository, OrdersMapper ordersMapper)
			: base(logger)
		{
			_ordersRepository = ordersRepository;
			_cartsRepository = cartsRepository;
			_ordersMapper = ordersMapper;
        }

		public async Task<OrderResponse?> SubmitOrder(string uuid, OrderRequest orderRequest)
		{
			try
			{
				var cartItems = await _cartsRepository.GetCart(uuid);
				var newOrder = _ordersMapper.Map(orderRequest);
				var order = await _ordersRepository.SubmitOrder(cartItems, newOrder);

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
		Task<OrderResponse?> SubmitOrder(string uuid, OrderRequest orderRequest);
    }
}

