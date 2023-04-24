using System;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class UserService : IUserService
	{
		private UserRepository userRepository;

		private readonly IConfiguration _configuration;

		public UserService(UserRepository userRepository, IConfiguration configuration)
		{
			this.userRepository = userRepository;
			_configuration = configuration;
		}

		public async Task<UserResponse?> GetOwnUserById(long id)
		{
			var userResponse = await userRepository.GetOwnUserById(id);

			return userResponse;
		}

		public async Task<UserResponse?> UpdateUserById(long id, UserRequest userRequest)
		{
			return await userRepository.UpdateUserById(id, userRequest);
		}
	}

	public interface IUserService
	{
		Task<UserResponse?> GetOwnUserById(long id);

		Task<UserResponse?> UpdateUserById(long id, UserRequest userRequest);
	}
}

