using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private ITokenManager _tokenManager;

        public AuthController(IAuthService authService, ITokenManager tokenManager)
        {
            _authService = authService;
            _tokenManager = tokenManager;
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

        // POST for sign-out: /users/sign-out
        [HttpPost]
        [Route("sign_out")]
        public async Task<ActionResult> SignOut([FromHeader] string authorization)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                try
                {
                    var accessToken = HttpContext.Request.Headers["Authorization"];
                    
                    var deactivatedToken = await _tokenManager.DeactivateToken(accessToken);

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

