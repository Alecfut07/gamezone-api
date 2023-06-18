using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;

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
				//var list = await _cartsRepository.GetCart(uuid);
				//var cartProducts = list.ConvertAll((tuple) =>
				//{
				//	var productId = tuple.Item1;
				//	var quantity = tuple.Item2;
				//	var productCacheEntry = tuple.Item3;
				//	return _cartsMapper.Map(productId, quantity, productCacheEntry);
				//});
				var newOrder = _ordersMapper.Map(userId, orderRequest, subtotal, tax, amount);
				var order = await _ordersRepository.SubmitOrder(newOrder);
				var orderResponse = _ordersMapper.Map(order);
				Console.WriteLine();
				return orderResponse;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, null);
				throw;
			}
		}

		public async Task<Response> SendEmail(string uuid, OrderResponse orderResponse)
		{
            try
            {
                //var list = await _cartsRepository.GetCart(uuid);
                //var cartProducts = list.ConvertAll((tuple) =>
                //{
                //    var productId = tuple.Item1;
                //    var quantity = tuple.Item2;
                //    var productCacheEntry = tuple.Item3;
                //    return _cartsMapper.Map(productId, quantity, productCacheEntry);
                //});

                //string subject = "Order Confirmation";
                //string message = "Thank you!\n" + "for shopping in GameZone.\n";

                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_SECRET");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
                var to = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
                var templateId = "d-d1b20d97efbf4efaa6c59048c80707f1";
                var dynamicTemplateData = new
                {
					date = orderResponse.CreateDate.ToString(),
                    orderId = orderResponse.Id.ToString(),
                    email = orderResponse.Email,
                    cartItems = orderResponse.OrderDetailsResponses,
					subtotal = orderResponse.Subtotal,
					tax = orderResponse.Tax,
					total = orderResponse.Grandtotal,
                };
                //var plainTextContent = message;
                //var htmlContent = "";
                var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
                var response = await client.SendEmailAsync(msg);
                return response;
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

		Task<Response> SendEmail(string uuid, OrderResponse orderResponse);
    }
}

