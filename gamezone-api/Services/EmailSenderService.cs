using System;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace gamezone_api.Services
{
	public class EmailSenderService : IEmailSenderService
	{
		public EmailSenderService()
		{
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
        Task<Response> SendEmail(string subject, string message);
    }
}

