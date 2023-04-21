using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Repositories
{
	public class UsersRepository
	{
		private GamezoneContext context;

		public UsersRepository(GamezoneContext dbContext)
		{
			context = dbContext;
		}

		public async Task<UserResponse> SignUp(UserRequest userRequest)
		{
			return null;
		}

		public async Task<UserResponse> SignIn(UserRequest userRequest)
		{
			return null;
		}
	}
}

