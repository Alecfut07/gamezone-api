using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class OrdersMapper
	{
		public OrdersMapper()
		{
		}

		public Order Map(OrderRequest orderRequest)
		{
			return new Order
			{
				Id = Guid.NewGuid(),
			};
		}
	}
}

