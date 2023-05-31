using System;
using System.Net;
using gamezone_api.Mappers;
using gamezone_api.Services;

namespace gamezone_api.Middlewares
{
    public class TokenManagerMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenManagerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var tokenManagerService = context.RequestServices.GetRequiredService<ITokenManager>();
            var header = context.Request.Headers["Authorization"].ToString();
            if (!string.IsNullOrEmpty(header))
            {
                var result = await tokenManagerService.IsRevoked(header);
                if (result)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                }
                else
                {
                    await _next(context);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}

