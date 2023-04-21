using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class UsersMapper
	{
		public User Map(UserRequest userRequest)
		{
			return new User
			{
				Email = userRequest.Email,
				Password = userRequest.Password,
			};
		}
	}
}

