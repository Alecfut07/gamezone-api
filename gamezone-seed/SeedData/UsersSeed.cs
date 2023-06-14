using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class UsersSeed
	{
        public static List<User>? InitData()
        {
            List<User> usersInit = new List<User>
            {
                new User() { Email = "admin@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword(Environment.GetEnvironmentVariable("PASSWORD"), workFactor: 12), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, AddressId = null, Birthdate = null, FirstName = null, LastName = null, Phone = null, IsAdmin = true },
                new User() { Email = "alec@gmail.com", Password = BCrypt.Net.BCrypt.HashPassword(Environment.GetEnvironmentVariable("PASSWORD"), workFactor: 12), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, AddressId = null, Birthdate = null, FirstName = null, LastName = null, Phone = null, IsAdmin = false }
            };
            return usersInit;
        }
    }
}

