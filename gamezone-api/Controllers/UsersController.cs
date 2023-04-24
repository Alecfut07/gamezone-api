using gamezone_api.Networking;
using gamezone_api.Services;
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

        // POST for sign-up: /users/sign-up
        [HttpPost]
        [Route("sign_up")]
        public async Task<ActionResult<AuthResponse>> SignUp([FromBody] AuthRequest authRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authResponse = await userService.CreateNewUser(authRequest);
                    HttpContext.Response.Headers.Add("Authorization", $"Bearer {authResponse.Token}");
                    return NoContent();
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
        }

        // POST for sign-in: /users/sign-in
        [HttpPost]
        [Route("sign_in")]
        public async Task<ActionResult<AuthResponse>> SignIn([FromBody] AuthRequest authRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var authResponse = await userService.Login(authRequest);
                    HttpContext.Response.Headers.Add("Authorization", $"Bearer {authResponse.Token}");
                    return NoContent();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            catch (ArgumentException ex)
            {
                return Unauthorized();
            }
        }
    }
}

