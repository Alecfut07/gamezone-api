using System;
namespace gamezone_api.Models.Stripe
{
	public record AddStripePayment(string CustomerId, string ReceiptEmail, string Description, string Currency, long Amount);
}

