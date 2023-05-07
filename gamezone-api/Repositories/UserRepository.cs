using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class UserRepository
	{
		private GamezoneContext context;
		private UsersMapper usersMapper;

		public UserRepository(GamezoneContext dbContext, UsersMapper usersMapper)
		{
			context = dbContext;
			this.usersMapper = usersMapper;
		}

		public async Task<UserResponse> GetOwnUserById(long id)
		{
			var user = await context.Users.FindAsync(id);

			var userResponse = usersMapper.Map(user);

			return userResponse;
		}

		public async Task<UserResponse?> UpdateUserById(long id, UserRequest userRequest)
		{
			var result = await context.Users
				.Where((u) => u.Id == id)
				.ExecuteUpdateAsync((user) =>
					user
						.SetProperty((user) => user.FirstName, userRequest.FirstName)
						.SetProperty((user) => user.LastName, userRequest.LastName)
						.SetProperty((user) => user.Email, userRequest.Email)
						.SetProperty((user) => user.Phone, userRequest.Phone)
						.SetProperty((user) => user.Birthdate, userRequest.Birthdate)
						);
			

			if (result > 0)
			{
				var updatedUser = await context.Users.FindAsync(id);
				//if (updatedUser.Address == null)
				//{
				//	var address = new Address();
				//	address.City = userRequest.Address.city;
				//}

				var userResponse = usersMapper.Map(updatedUser);
				return userResponse;
			}
			else
			{
				throw new ArgumentException();
			}
		}
	}
}

