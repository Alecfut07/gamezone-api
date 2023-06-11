using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class OrdersMapper
	{
		private ProductsMapper _productsMapper;

		public OrdersMapper(ProductsMapper productsMapper)
		{
			_productsMapper = productsMapper;
        }

		public Order Map(long userId, OrderRequest orderRequest, long subtotal, long tax, long amount)
		{
			return new Order
			{
				Id = Guid.NewGuid(),
				Tax = (decimal)(tax / 100),
				Subtotal = (decimal)(subtotal / 100),
				Grandtotal = (decimal)(amount / 100),
				Email = orderRequest.Customer.Email,
				UserId = userId,
				OrderDetails = Map(orderRequest.OrderDetailRequests.ToList()),
			};
		}

		public OrderResponse Map(Order order)
		{
			return new OrderResponse
			{
				Id = order.Id,
				Tax = order.Tax,
				Subtotal = order.Subtotal,
				Grandtotal = order.Grandtotal,
				Email = order.Email,
				UserId = order.UserId,
				OrderDetailsResponses = Map(order.OrderDetails.ToList())
			};
		}

		public OrderDetailResponse Map(OrderDetail orderDetail)
		{
			return new OrderDetailResponse
			{
				Id = orderDetail.Id,
				Subtotal = orderDetail.Subtotal,
				Tax = orderDetail.Tax,
				Grandtotal = orderDetail.Grandtotal,
				Quantity = orderDetail.Quantity,
				Order = Map(orderDetail.Order),
				Product = _productsMapper.Map(orderDetail.Product)
			};
		}

		public List<OrderDetailResponse> Map(List<OrderDetail> orderDetails)
		{
			return orderDetails.ConvertAll<OrderDetailResponse>((odr) => Map(odr));
		}

		public OrderDetail Map(OrderDetailRequest orderDetailRequest)
		{
			return new OrderDetail
			{
				Id = orderDetailRequest.Id,
				OrderId = orderDetailRequest.OrderId,
                Subtotal = orderDetailRequest.Subtotal,
                Tax = orderDetailRequest.Tax,
                Grandtotal = orderDetailRequest.Grandtotal,
                Quantity = orderDetailRequest.Quantity,
				ProductId = orderDetailRequest.ProductId,
			};
		}

		public List<OrderDetail> Map(List<OrderDetailRequest> orderDetailRequests)
		{
			return orderDetailRequests.ConvertAll<OrderDetail>((odr) => Map(odr));
		}
	}
}

