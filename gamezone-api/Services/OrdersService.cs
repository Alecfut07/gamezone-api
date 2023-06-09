using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class OrdersService : BaseService, IOrdersService
	{
		private IOrdersRepository _ordersRepository;
		private OrdersMapper _ordersMapper;

		public OrdersService(ILogger logger, IOrdersRepository ordersRepository, OrdersMapper ordersMapper)
			: base(logger)
		{
			_ordersRepository = ordersRepository;
			_ordersMapper = ordersMapper;
        }

		public async Task<OrderResponse?> SaveNewOrder(OrderRequest orderRequest)
		{
			try
			{
				var order = await _ordersRepository.SaveNewOrder(null);

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
		Task<OrderResponse?> SaveNewOrder(OrderRequest orderRequest);
    }
}

