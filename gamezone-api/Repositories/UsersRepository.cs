using System;
using System.Text.RegularExpressions;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;

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

        public async Task<UserResponse> CreateNewUser(UserRequest userRequest)
        {
            var newUser = usersMapper.Map(userRequest);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password, workFactor: 12);
            newUser.CreateDate = DateTime.UtcNow;
            newUser.UpdateDate = DateTime.UtcNow;

            context.Users.Add(newUser);
            await context.SaveChangesAsync();

            var userResponse = usersMapper.Map(newUser);

            return userResponse;
        }

        public async Task<UserResponse> SignIn(UserRequest userRequest)
        {
            return null;
        }
    }
}

