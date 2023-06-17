using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace gamezone_api.Services
{
    public class EmailSenderService : BaseService, IEmailSenderService
    {
        private CartsRepository _cartsRepository;
        private CartsMapper _cartsMapper;

        public EmailSenderService(ILogger logger, CartsRepository cartsRepository, CartsMapper cartsMapper)
            : base(logger)
        {
            _cartsRepository = cartsRepository;
            _cartsMapper = cartsMapper;
        }

        public async Task<Response> SendEmail(string uuid, OrderResponse orderResponse)
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

                string subject = "Order Confirmation";
                string message = "Thank you!\n" + "for shopping in GameZone.\n";

                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_SECRET");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
                var to = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
                var templateId = "d-d1b20d97efbf4efaa6c59048c80707f1";
                var dynamicTemplateData = new
                {
                    orderId = orderResponse.Id.ToString(),
                    email = $"{Guid.NewGuid().ToString()}",
                    firstName = "Alec",
                    message = message,
                    cart = cartProducts,
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

        public async Task<Response> SendEmail(string subject, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_SECRET");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "gamezone-api");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec");
            var plainTextContent = message;
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            return response;
        }
    }

    public interface IEmailSenderService
    {
        Task<Response> SendEmail(string uuid, OrderResponse orderResponse);
        Task<Response> SendEmail(string subject, string message);
    }
}

