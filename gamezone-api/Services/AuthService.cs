using System;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;

namespace gamezone_api.Services
{
    public class AuthService : IAuthService
    {
        private AuthRepository authRepository;

        private readonly IConfiguration _configuration;

        public AuthService(AuthRepository authRepository, IConfiguration configuration)
        {
            this.authRepository = authRepository;
            _configuration = configuration;
        }

        private bool ValidateEmail(string email)
        {
            var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);

            return regex.IsMatch(email);
        }

        private string GenerateToken(User user)
        {
            var audience = _configuration["JWT:ValidAudience"];
            var issuer = _configuration["JWT:ValidIssuer"];
            var secret = _configuration["JWT:Secret"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var signinCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                },
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        public async Task<AuthResponse> CreateNewUser(AuthRequest authRequest)
        {
            if (!ValidateEmail(authRequest.Email))
            {
                throw new ArgumentException();
            }
            else
            {
                var user = await authRepository.CreateNewUser(authRequest);

                var authResponse = new AuthResponse { Token = GenerateToken(user) };

                return authResponse;
            }
        }

        private bool ValidatePassword(string password, string encryptedPassword)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
            return verified;
        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            if (!ValidateEmail(authRequest.Email))
            {
                throw new ArgumentException();
            }
            else
            {
                var user = await authRepository.FindUserByEmail(authRequest.Email);

                if (!ValidatePassword(authRequest.Password, user.Password))
                {
                    throw new ArgumentException();
                }
                else
                {
                    var authResponse = new AuthResponse { Token = GenerateToken(user) };

                    return authResponse;
                }
            }
        }
    }

    public interface IAuthService
    {
        Task<AuthResponse> CreateNewUser(AuthRequest authRequest);

        Task<AuthResponse> Login(AuthRequest authRequest);
    }
}

