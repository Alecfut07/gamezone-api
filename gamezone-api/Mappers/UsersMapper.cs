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

		public UserResponse Map(User user)
		{
			return new UserResponse
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				Phone = user.Phone,
				Birthdate = user.Birthdate,
				CreateDate = user.CreateDate,
				UpdateDate = user.UpdateDate
			};
		}
	}
}

