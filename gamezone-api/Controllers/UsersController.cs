using System;
using System.Security.Claims;
using gamezone_api.Helpers;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
    [Authorize]
    public class UsersController : ControllerBase
	{
		IUserService userService;

		public UsersController(IUserService userService)
		{
			this.userService = userService;
		}

		// GET -> /users/me 
		[HttpGet]
		[Route("me")]
		public async Task<ActionResult<UserResponse>> GetOwnUser()
		{
			var userId = long.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await userService.GetOwnUserById(userId);

            return Ok(user);
		}

		// PUT -> /users/me
		[HttpPut]
		[Route("me")]
		public async Task<ActionResult<UserResponse>> UpdateUser([FromBody] UserRequest userRequest)
		{
            string? authHeader = HttpContext.Request.Headers["Authorization"];
            var userId = TokenHelper.GetUserId(authHeader);

            var updatedUser = await userService.UpdateUserById(userId, userRequest);

            return Ok(updatedUser);
		}
	}
}

