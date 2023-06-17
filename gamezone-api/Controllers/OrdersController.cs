using System;
using System.Security.Claims;
using gamezone_api.Application;
using gamezone_api.Helpers;
using gamezone_api.Models.Stripe;
using gamezone_api.Networking;
using gamezone_api.Services;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private IPaymentsService _paymentsService;
        private IOrdersService _ordersService;

        public OrdersController(IPaymentsService paymentsService, IOrdersService ordersService)
        {
            _paymentsService = paymentsService;
            _ordersService = ordersService;
        }

        // POST: /orders
        [HttpPost]
        public async Task<ActionResult<OrderResponse?>> SubmitOrder([FromBody] OrderRequest orderRequest, CancellationToken ct)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                try
                {
                    var uuid = HttpContext.Request.Cookies["uuid"];
                    var accessToken = HttpContext.Request.Headers["Authorization"];
                    var userId = TokenHelper.GetUserId(accessToken);

                    // Step 1: Add customer and payment into stripe service.
                    var stripeCustomer = await _paymentsService.AddStripeCustomerAsync(orderRequest.Customer, ct);
                    var paymentResponse = await _paymentsService.AddStripePaymentAsync(uuid, stripeCustomer.CustomerId, orderRequest.Address, orderRequest.Payment, ct);

                    // Step 2: Save order and its order details in the database.
                    var orderResponse = await _ordersService.SubmitOrder(uuid, userId, orderRequest, paymentResponse.Subtotal, paymentResponse.Tax, paymentResponse.Amount);

                    // Step 3: Send an email with order confirmation.
                    var emailResponse = await _ordersService.SendEmail(uuid, orderResponse);
                    return Ok(emailResponse);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}

