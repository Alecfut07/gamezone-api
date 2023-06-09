﻿using System;
using gamezone_api.Models;
using gamezone_api.Models.Stripe;
using gamezone_api.Networking;
using gamezone_api.Services;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
using Stripe.Tax;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace gamezone_api.Controllers.Stripe
{
    [ApiController]
    [Route("/api/[controller]")]
    public class StripeController : ControllerBase
    {
        private readonly IPaymentsService _stripeService;
        private readonly ICartsService _cartsService;

        public StripeController(IPaymentsService stripeService, ICartsService cartsService)
        {
            _stripeService = stripeService;
            _cartsService = cartsService;
        }

        //[HttpPost("customer/add")]
        //public async Task<ActionResult<StripeCustomer>> AddStripeCustomer([FromBody] Models.Stripe.Customer customer, CancellationToken ct)
        //{
        //    StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(customer, ct);

        //    return StatusCode(StatusCodes.Status200OK, createdCustomer);
        //}

        //[HttpPost("payment/add")]
        //public async Task<ActionResult<StripePayment>> AddStripePayment([FromBody] Payment payment, Models.Address address, CancellationToken ct)
        //{
        //    var uuid = HttpContext.Request.Cookies["uuid"];
        //    StripePayment createdPayment = await _stripeService.AddStripePaymentAsync(uuid, address, payment, ct);

        //    return StatusCode(StatusCodes.Status200OK, createdPayment);
        //}

        [HttpPost("calculate_estimated_tax")]
        public async Task<ActionResult> CalculateEstimatedTax([FromBody] SubtotalRequest subtotalRequest)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            if (ipAddress != null)
            {
                var options = new CalculationCreateOptions
                {
                    Currency = "usd",
                    LineItems = new List<CalculationLineItemOptions>
                {
                    new CalculationLineItemOptions { Amount = subtotalRequest.Amount, Reference = "L1" },
                },
                    CustomerDetails = new CalculationCustomerDetailsOptions { IpAddress = "107.2.247.241" },
                };
                var service = new CalculationService();
                var estimatedCalculation = service.Create(options);
                string formattedEstimatedTaxValue = string.Format(
                    "{0:#.00}", Convert.ToDouble(estimatedCalculation.TaxAmountExclusive) / 100);

                // Return the estimated tax amount as a JSON response
                var preview = new Dictionary<string, dynamic>
                {
                    { "estimated_tax_amount", Convert.ToDouble(formattedEstimatedTaxValue) },
                };

                return Ok(preview);
            }
            return StatusCode(StatusCodes.Status500InternalServerError);
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
            string formattedTaxValue = string.Format(
            "{0:#.00}", Convert.ToDouble(calculation.TaxAmountExclusive) / 100);

            // Return the tax amount as a JSON response
            var preview = new Dictionary<string, dynamic>
            {
                { "tax_amount", Convert.ToDouble(formattedTaxValue) },
            };

            return Ok(preview);
        }
    }
}

