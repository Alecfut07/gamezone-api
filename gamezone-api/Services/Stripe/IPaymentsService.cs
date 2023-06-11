using System;
using gamezone_api.Models.Stripe;
using gamezone_api.Networking;

namespace gamezone_api.Services.Stripe
{
	public interface IPaymentsService
	{
        Task<StripeCustomer> AddStripeCustomerAsync(Customer customer, CancellationToken ct);
        Task<StripePayment> AddStripePaymentAsync(string uuid, string stripeCustomerId, AddressRequest address, Payment payment, CancellationToken ct);
    }
}

