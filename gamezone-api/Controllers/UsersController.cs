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
        [Route("sign_up")]
        public async Task<ActionResult<UserResponse>> SignUp([FromBody] UserRequest userRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await userService.CreateNewUser(userRequest);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return NoContent();
        }

        // POST for sign-in: /users/sign-in
        [HttpPost]
        [Route("sign_in")]
        public async Task<ActionResult<UserResponse>> SignIn(UserRequest userRequest)
        {
            return Ok();
        }
    }
}

