using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class UsersMapper
	{
		public User Map(AuthRequest authRequest)
		{
			return new User
			{
				Email = authRequest.Email,
				Password = authRequest.Password,
			};
		}
	}
}

