using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace gamezone_api.Helpers
{
	public class TokenHelper
	{
		private static string GetAccessToken(string authHeader)
		{
			var components = authHeader.Split(" ");

			return components.Last();
		}

		public static long GetUserId(string? header)
		{
			if (header == null)
			{
				throw new ArgumentNullException();
			}

            var token = GetAccessToken(header);

			if (token == null)
			{
				throw new ArgumentException();
			}
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userId = long.Parse(jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value);

            return userId;
		}
	}
}

