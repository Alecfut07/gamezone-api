using System;
using gamezone_api.Helpers;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		// GET -> /users/me 
		[HttpGet]
		[Route("me")]
		public async Task<ActionResult<UserResponse>> GetOwnUser()
		{
			try
			{
                string? authHeader = HttpContext.Request.Headers["Authorization"];
                var userId = TokenHelper.GetUserId(authHeader);

                var user = await userService.GetOwnUserById(userId);

                return Ok(user);
            }
			catch (ArgumentNullException ex)
			{
				return Unauthorized();
			}
			catch (ArgumentException ex)
			{
				return Unauthorized();
			}
		}

		// PUT -> /users/me
		[HttpPut]
		[Route("me")]
		public async Task<ActionResult<UserResponse>> UpdateUser([FromBody] UserRequest userRequest)
		{
			try
			{
                string? authHeader = HttpContext.Request.Headers["Authorization"];
                var userId = TokenHelper.GetUserId(authHeader);

                var updatedUser = await userService.UpdateUserById(userId, userRequest);

                return Ok(updatedUser);
            }
			catch (ArgumentNullException ex)
			{
				return Unauthorized();
			}
			catch (ArgumentException ex)
			{
				return Unauthorized();
			}
		}
	}
}

