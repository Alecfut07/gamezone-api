using System;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("/api/sendgrid/[controller]")]
	public class EmailSenderController : ControllerBase
	{
		//private IEmailSenderService _emailSenderService;

		//public EmailSenderController(IEmailSenderService emailSenderService)
		//{
		//	_emailSenderService = emailSenderService;
  //      }

		[HttpPost]
		public async Task<ActionResult> SendEmail()
		{
			string subject = "Order Confirmation";
			string message = "Thank you!\n" + "for shopping in GameZone.\n";
            //var response = await _emailSenderService.SendEmail(subject, message);

            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_SECRET");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
            //var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_EMAIL_TEST"), "Alec Ortega");
            var templateId = "d-b87a3075d0464c35aabebd357d5cc80b";
            var dynamicTemplateData = new
            {
                subject = subject,
                orderNumber = $"{Guid.NewGuid().ToString()}",
                firstName = "Alec",
                message = message,
            };
            //var plainTextContent = message;
            //var htmlContent = "";
            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, dynamicTemplateData);
            var response = await client.SendEmailAsync(msg);
            return Ok(response);
		}
	}
}

