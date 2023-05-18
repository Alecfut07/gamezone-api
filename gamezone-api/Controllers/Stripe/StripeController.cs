using System;
using gamezone_api.Models.Stripe;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Stripe
{
	[ApiController]
	[Route("[controller]")]
	public class StripeController : ControllerBase
	{
        private readonly IStripeAppService _stripeService;

        public StripeController(IStripeAppService stripeService)
		{
            _stripeService = stripeService;
        }

        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer([FromBody] AddStripeCustomer customer, CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(customer, ct);

            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }

        [HttpPost("payment/add")]
        public async Task<ActionResult<StripePayment>> AddStripePayment([FromBody] AddStripePayment payment, CancellationToken ct)
        {
            StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(payment, ct);

            return StatusCode(StatusCodes.Status200OK, createdPayment);
        }
    }
}

