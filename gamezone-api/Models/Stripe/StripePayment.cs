using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Models.Stripe
{
	public record StripePayment(string CustomerId, string PaymentId, string ReceiptEmail, string Description, string Currency, long Subtotal, long Tax, long Amount);
}

