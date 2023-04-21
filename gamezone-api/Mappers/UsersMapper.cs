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

		public UserResponse Map(User user)
		{
			return new UserResponse
			{
				Id = user.Id,
				Email = user.Email,
				Password = user.Password,
				CreateDate = user.CreateDate,
				UpdateDate = user.UpdateDate
			};
		}
	}
}

