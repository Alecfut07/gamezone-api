using System;
using gamezone_api.Mappers;
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
						.SetProperty((user) => user.Email, userRequest.Email)
						);

			if (result > 0)
			{
				var updatedUser = await context.Users.FindAsync(id);

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

