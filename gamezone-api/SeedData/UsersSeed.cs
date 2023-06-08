using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
    public class UsersSeed
    {
        private readonly GamezoneContext _context;

        public UsersSeed(GamezoneContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Users.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        //Id = 1,
                        Email = "admin@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword(Environment.GetEnvironmentVariable("PASSWORD"), workFactor: 12),
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        AddressId = null,
                        Birthdate = null,
                        FirstName = null,
                        LastName = null,
                        Phone = null,
                        IsAdmin = true
                    },
                    new User()
                    {
                        //Id = 2,
                        Email = "alec@gmail.com",
                        Password = BCrypt.Net.BCrypt.HashPassword(Environment.GetEnvironmentVariable("PASSWORD"), workFactor: 12),
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        AddressId = null,
                        Birthdate = null,
                        FirstName = null,
                        LastName = null,
                        Phone = null,
                        IsAdmin = false
                    }
                };

                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
        }
    }
}

