using System;
using Microsoft.AspNetCore.Mvc;
using gamezone_api.Networking;
using gamezone_api.Models;
using gamezone_api.Services;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class UsersController : ControllerBase
	{
		IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		// POST for sign-up: /users/sign-up
		[HttpPost]
		public async Task<ActionResult<UserResponse>> SignUp([FromBody] UserRequest userRequest)
		{
			return Ok();
		}

		// POST for sign-in: /users/sign-in
		[HttpPost]
		public async Task<ActionResult<UserResponse>> SignIn([FromBody] UserRequest userRequest)
		{
			return Ok();
		}
	}
}

