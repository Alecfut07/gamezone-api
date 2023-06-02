using System;
using gamezone_api.Models;
using gamezone_api.Models.Stripe;
using gamezone_api.Networking;
using gamezone_api.Services;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Stripe.Tax;

namespace gamezone_api.Controllers.Stripe
{
    [ApiController]
    [Route("[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IStripeAppService _stripeService;
        private readonly ICartsService _cartsService;

        public StripeController(IStripeAppService stripeService, ICartsService cartsService)
        {
            _stripeService = stripeService;
            _cartsService = cartsService;
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

        [HttpPost("calculate_tax")]
        public async Task<ActionResult> CalculateTax([FromBody] AddressRequest addressRequest)
        {
            var uuid = HttpContext.Request.Cookies["uuid"];
            if (string.IsNullOrEmpty(uuid))
            {
                return NotFound();
            }
            CartResponse cartResponse = await _cartsService.GetCart(uuid);
            // Convert each cart item to a Stripe line item object
            var lineItems = new List<CalculationLineItemOptions>();
            foreach (var cartItem in cartResponse.Products)
            {
                lineItems.Add(new CalculationLineItemOptions
                {
                    Reference = cartItem.ProductId.ToString(),
                    Amount = (long?)(cartItem.Quantity * cartItem.Price),
                    Quantity = cartItem.Quantity
                });
            }

            // Create a tax calculation using the Stripe API
            var options = new CalculationCreateOptions
            {
                Currency = "USD",
                LineItems = lineItems,
                CustomerDetails = new CalculationCustomerDetailsOptions
                {
                    Address = new AddressOptions
                    {
                        Line1 = addressRequest.Line1,
                        Line2 = addressRequest.Line2,
                        City = addressRequest.City,
                        State = addressRequest.State,
                        PostalCode = addressRequest.ZipCode,
                        Country = addressRequest.Country,
                    },
                    AddressSource = "billing",
                },
                Expand = new List<string> { "line_items.data.tax_breakdown" },
            };
            var service = new CalculationService();
            var calculation = service.Create(options);

            // Return the tax amount as a JSON response
            var preview = new Dictionary<string, dynamic>
            {
                { "tax_amount", Convert.ToDouble(calculation.TaxAmountExclusive) },
            };

            return Ok(preview);
        }
    }
}

