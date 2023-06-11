using System;
using System.Text.Json.Serialization;
using Stripe;

namespace gamezone_api.Models.Stripe
{
	//public record Payment(string CustomerId, string ReceiptEmail, string Description, string Currency);

	public class Payment
	{
		[JsonPropertyName("customer_id")]
		public string CustomerId { get; set; }

		[JsonPropertyName("receipt_email")]
		public string ReceiptEmail { get; set; }

		[JsonPropertyName("description")]
		public string Description { get; set; }

		[JsonPropertyName("currency")]
		public string Currency { get; set; }
	}
}

