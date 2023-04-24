using System;
using System.Text.RegularExpressions;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
    public class UsersRepository
    {
        private GamezoneContext context;
        private UsersMapper usersMapper;

        public UsersRepository(GamezoneContext dbContext, UsersMapper usersMapper)
        {
            context = dbContext;
            this.usersMapper = usersMapper;
        }

        public async Task<User> CreateNewUser(AuthRequest authRequest)
        {
            var newUser = usersMapper.Map(authRequest);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(authRequest.Password, workFactor: 12);
            newUser.CreateDate = DateTime.UtcNow;
            newUser.UpdateDate = DateTime.UtcNow;

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            return newUser;
        }

        public async Task<User> FindUserByEmail(string email)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}

