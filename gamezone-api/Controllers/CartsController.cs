using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartsController : ControllerBase
	{
		ICartsService cartsService;

		public CartsController(ICartsService cartsService)
		{
			this.cartsService = cartsService;
		}

		[HttpGet]
		public async Task<IActionResult> GetCart()
		{
			try
			{
				var uuid = HttpContext.Request.Cookies["uuid"];
				await cartsService.GetCart(uuid);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> AddItemToCart([FromBody] CartRequest cartRequest)
		{
			try
			{
				var uuid = HttpContext.Request.Cookies["uuid"];
				await cartsService.AddItemToCart(uuid, cartRequest);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpPut]
		[Route("update")]
		public async Task<IActionResult> UpdateQuantity([FromBody] CartRequest cartRequest)
		{
			try
			{
				var uuid = HttpContext.Request.Cookies["uuid"];
				await cartsService.UpdateQuantity(uuid, cartRequest);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}

		[HttpDelete]
		[Route("remove")]
		public async Task<IActionResult> RemoveItemInCart()
		{
			try
			{
				var uuid = HttpContext.Request.Cookies["uuid"];
				await cartsService.RemoveItemInCart(uuid);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}

