using System;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;

namespace gamezone_api.Services
{
    public class TokenManagerService : ITokenManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private TokenManagerRepository _tokenManagerRepository;

        public TokenManagerService(TokenManagerRepository tokenManagerRepository)
        {
            _tokenManagerRepository = tokenManagerRepository;
        }

        public async Task<bool> IsRevoked(string header)
        {
            var jti = TokenHelper.GetJti(header);
            return await _tokenManagerRepository.IsRevoked(jti);
        }

        public async Task<JwtDenyList> DeactivateToken(string header)
        {
            var jti = TokenHelper.GetJti(header);
            var jwtDenyList = new JwtDenyList
            {
                Jti = jti,
                ExpiryDate = DateTime.Now
            };
            var createdJwtDenyList = await _tokenManagerRepository.SaveDeactivatedToken(jwtDenyList);
            return createdJwtDenyList;
        }
    }

    public interface ITokenManager
    {
        Task<bool> IsRevoked(string header);
        Task<JwtDenyList> DeactivateToken(string token);
    }
}

