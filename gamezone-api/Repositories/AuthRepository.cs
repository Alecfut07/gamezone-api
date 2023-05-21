using System;
using System.Text.RegularExpressions;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
    public class AuthRepository
    {
        private GamezoneContext _context;

        public AuthRepository(GamezoneContext context)
        {
            _context = context;
        }

        public async Task<User> CreateNewUser(User user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, workFactor: 12);
            user.CreateDate = DateTime.UtcNow;
            user.UpdateDate = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> FindUserByEmail(string email)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}

