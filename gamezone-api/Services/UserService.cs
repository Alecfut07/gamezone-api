using System;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class UserService : IUserService
	{
		private UsersRepository usersRepository;

		public UserService(UsersRepository usersRepository)
		{
			this.usersRepository = usersRepository;
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

	public interface IUserService
	{
		Task<UserResponse> SignUp(UserRequest userRequest);

		Task<UserResponse> SignIn(UserRequest userRequest);
	}
}

