using System;
using System.Configuration;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;

namespace gamezone_api.Services
{
    public class AuthService : BaseService, IAuthService
    {
        private readonly IConfiguration _configuration;
        private AuthRepository _authRepository;
        private UsersMapper _usersMapper;

        public AuthService(Microsoft.Extensions.Logging.ILogger logger, IConfiguration configuration, AuthRepository authRepository, UsersMapper usersMapper)
            : base(logger)
        {
            _configuration = configuration;
            _authRepository = authRepository;
            _usersMapper = usersMapper;
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
            DateTimeOffset now = DateTimeOffset.UtcNow;
            long unixTimeMilliseconds = now.ToUnixTimeMilliseconds();
            var tokeOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, unixTimeMilliseconds.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                },
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signinCredentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        public async Task<AuthResponse> CreateNewUser(AuthRequest authRequest)
        {
            try
            {
                if (!ValidateEmail(authRequest.Email))
                {
                    throw new ArgumentException();
                }
                else
                {
                    var newUser = _usersMapper.Map(authRequest);
                    var user = await _authRepository.CreateNewUser(newUser);

                    var authResponse = new AuthResponse { Token = GenerateToken(user) };

                    return authResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        private bool ValidatePassword(string password, string encryptedPassword)
        {
            bool verified = BCrypt.Net.BCrypt.Verify(password, encryptedPassword);
            return verified;
        }

        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {
            try
            {
                if (!ValidateEmail(authRequest.Email))
                {
                    throw new ArgumentException();
                }
                else
                {
                    var user = await _authRepository.FindUserByEmail(authRequest.Email);

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
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        //public async Task<AuthResponse> SignOut(AuthRequest authRequest)
        //{
        //    try
        //    {
        //        if (!ValidateEmail(authRequest.Email))
        //        {
        //            throw new ArgumentException();
        //        }
        //        else
        //        {
        //            var user = await _authRepository.FindUserByEmail(authRequest.Email);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, null);
        //        throw;
        //    }
        //}
    }

    public interface IAuthService
    {
        Task<AuthResponse> CreateNewUser(AuthRequest authRequest);

        Task<AuthResponse> Login(AuthRequest authRequest);
    }
}

