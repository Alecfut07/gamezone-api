using System;
using gamezone_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class TokenManagerRepository
	{
		private GamezoneContext _context;

		public TokenManagerRepository(GamezoneContext context)
		{
			_context = context;
		}

		public async Task<JwtDenyList> SaveDeactivatedToken(JwtDenyList jwtDenyList)
		{
			await _context.JwtDenyLists.AddAsync(jwtDenyList);
			await _context.SaveChangesAsync();

			var newJwtDeactivatedToken = await _context.JwtDenyLists.SingleAsync(jwtDL => jwtDL.Id == jwtDenyList.Id);
			return newJwtDeactivatedToken;
		}

		public async Task<bool> IsRevoked(string token)
		{
			return await _context.JwtDenyLists.AnyAsync(jwtDL => jwtDL.Jti == token);	
		}
	}
}

