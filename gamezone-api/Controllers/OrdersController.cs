using System;
using gamezone_api.Networking;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        //private IOrdersService _ordersService;

        //public OrdersController(IOrdersService ordersService)
        //{
        //    _ordersService = ordersService;
        //}

        //// GET: /orders
        //[HttpGet]
        //public async Task<ActionResult<OrderResponse>> GetOrders()
        //{
        //    try
        //    {
        //        var products = await _ordersService.GetOrders();
        //        return Ok(products);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //}

        //// POST: /orders
        //[HttpPost]
        //public async Task<ActionResult<OrderResponse?>> SaveNewOrder([FromBody] OrderRequest productRequest)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError);
        //    }
        //    else
        //    {
        //        try
        //        {
        //            var userLoggedIn = await GetLoggedInUser();
        //            if (userLoggedIn.IsAdmin)
        //            {
        //                string protocol = HttpContext.Request.Host.Host;
        //                var newProduct = await _productService.SaveNewProduct(productRequest);
        //                return Ok(newProduct);
        //            }
        //            else
        //            {
        //                return Forbid();
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            return StatusCode(StatusCodes.Status500InternalServerError);
        //        }
        //    }
        //}
    }
}

