using System;
using System.Security.Claims;
using gamezone_api.Application;
using gamezone_api.Models.Stripe;
using gamezone_api.Networking;
using gamezone_api.Services;
using gamezone_api.Services.Stripe;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
                    var userId = long.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                    var stripeCustomer = await _paymentsService.AddStripeCustomerAsync(orderRequest.Customer, ct);
                    var paymentResponse = await _paymentsService.AddStripePaymentAsync(uuid, stripeCustomer.CustomerId, orderRequest.Address, orderRequest.Payment, ct);
                    var orderResponse = await _ordersService.SubmitOrder(uuid, orderRequest);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}

