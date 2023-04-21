using System;
using System.Text.RegularExpressions;
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

        private bool ValidateEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        public async Task<UserResponse> CreateNewUser(UserRequest userRequest)
        {
            if (!ValidateEmail(userRequest.Email))
            {
                throw new ArgumentException();
            }
            else
            {
                var userResponse = await usersRepository.CreateNewUser(userRequest);
                return userResponse;
            }
        }

        private bool ValidatePassword(string password, string encryptedPassword)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
            return verified;
        }

        public async Task<UserResponse> SignIn(UserRequest userRequest)
        {
            return null;
        }
    }

    public interface IUserService
    {
        Task<UserResponse> CreateNewUser(UserRequest userRequest);

        Task<UserResponse> SignIn(UserRequest userRequest);
    }
}

