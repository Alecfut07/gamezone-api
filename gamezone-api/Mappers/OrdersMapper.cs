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

		public Order Map(long userId, OrderRequest orderRequest)
		{
			Guid id = Guid.NewGuid();
			//decimal subtotalValue = (decimal)(subtotal / 100);
			//decimal taxValue = (decimal)(tax / 100);
			//decimal amountValue = (decimal)(amount / 100);

            return new Order
			{
				Id = id,
				Tax = 0,
				Subtotal = 0,
				Grandtotal = 0,
				Email = orderRequest.Customer.Email,
				UserId = userId,
				OrderDetails = Map(id, orderRequest.OrderDetailRequests.ToList()),
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

		public OrderDetail Map(Guid orderId, OrderDetailRequest orderDetailRequest)
		{
			return new OrderDetail
			{
				Id = Guid.NewGuid(),
				//OrderId = orderDetailRequest.OrderId,
				OrderId = orderId,
				Price = orderDetailRequest.Price,
				Subtotal = orderDetailRequest.Subtotal,
				Tax = orderDetailRequest.Tax,
				Grandtotal = orderDetailRequest.Grandtotal,
                Quantity = orderDetailRequest.Quantity,
				ProductId = orderDetailRequest.ProductId,
			};
		}

		public List<OrderDetail> Map(Guid orderId, List<OrderDetailRequest> orderDetailRequests)
		{
			return orderDetailRequests.ConvertAll<OrderDetail>((odr) => Map(orderId, odr));
		}
	}
}

