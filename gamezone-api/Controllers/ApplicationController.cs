using System;
using gamezone_api.Models;
using System.Security.Claims;
using gamezone_api.Networking;
using Microsoft.AspNetCore.Mvc;
using gamezone_api.Services;

namespace gamezone_api.Controllers
{
	public abstract class ApplicationController: ControllerBase
	{
        private IUserService _usersService;

        public ApplicationController(IUserService usersService)
        {
            _usersService = usersService;
        }

		protected async Task<UserResponse> GetLoggedInUser()
        {
            var userId = long.Parse(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            return await _usersService.GetOwnUserById(userId);
        }
	}
}

