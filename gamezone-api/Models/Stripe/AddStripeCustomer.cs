using System;
namespace gamezone_api.Models.Stripe
{
    public record AddStripeCustomer(string Email, string Name, AddStripeCard CreditCard);
}

