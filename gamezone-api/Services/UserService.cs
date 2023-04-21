using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.IdentityModel.Tokens;

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

        private string GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: ConfigurationManager.AppSetting["JWT:ValidIssuer"],
                audience: ConfigurationManager.AppSetting["JWT:ValidAudience"],
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        public async Task<UserResponse> CreateNewUser(UserRequest userRequest)
        {
            if (!ValidateEmail(userRequest.Email))
            {
                throw new ArgumentException();
            }
            else
            {
                await usersRepository.CreateNewUser(userRequest);

                var userResponse = new UserResponse { Token = GenerateToken() };

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

