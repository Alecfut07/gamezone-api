﻿using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("users")]
    public class AuthController : ControllerBase
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST for sign-up: /users/sign-up
        [HttpPost]
        [Route("sign_up")]
        public async Task<ActionResult<AuthResponse>> SignUp([FromBody] AuthRequest authRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                try
                {
                    var authResponse = await _authService.CreateNewUser(authRequest);
                    HttpContext.Response.Headers.Add("Authorization", $"Bearer {authResponse.Token}");
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // POST for sign-in: /users/sign-in
        [HttpPost]
        [Route("sign_in")]
        public async Task<ActionResult<AuthResponse>> SignIn([FromBody] AuthRequest authRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                try
                {
                    var authResponse = await _authService.Login(authRequest);
                    HttpContext.Response.Headers.Add("Authorization", $"Bearer {authResponse.Token}");
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return Unauthorized();
                }

            }
        }
    }
}

