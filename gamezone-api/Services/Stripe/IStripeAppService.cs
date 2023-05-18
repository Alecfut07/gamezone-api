using System;
using gamezone_api.Models.Stripe;

namespace gamezone_api.Services.Stripe
{
	public interface IStripeAppService
	{
        Task<StripeCustomer> AddStripeCustomerAsync(AddStripeCustomer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(AddStripePayment payment, CancellationToken ct);
    }
}

