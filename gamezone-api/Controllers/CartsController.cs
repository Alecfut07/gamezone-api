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

		[HttpPost]
		[Route("add")]
		public async Task<IActionResult> AddItemToCart([FromBody] CartRequest cartRequest)
		{
			var uuid = HttpContext.Request.Cookies["uuid"];

			await cartsService.AddItemToCart(uuid, cartRequest);

			return NoContent();
		}
	}
}

