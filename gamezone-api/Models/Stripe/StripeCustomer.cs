using System;
namespace gamezone_api.Models.Stripe
{
	public record StripeCustomer(string Name, string Email, string CustomerId);
}

