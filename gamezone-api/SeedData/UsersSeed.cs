using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class UsersSeed
	{
		public static List<User> InitData()
		{
			List<User> usersInit = new List<User>
			{
				new User() { Id = 1, FirstName = "Alec", LastName = "Ortega", Email = "alec@gmail.com", Password = "123456", Phone = "(664)329-1243", Birthday = new DateTime(2000, 1, 4), AddressId = 1, Role = "admin", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
				new User() { Id = 2, FirstName = "Alexis", LastName = "Ortega", Email = "alexis@gmail.com", Password = "123456", Phone = "(664)937-3897", Birthday = new DateTime(1990, 6, 4), AddressId = 2, Role = "admin", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
				new User() { Id = 3, FirstName = "Armando", LastName = "Ortega", Email = "armando@gmail.com", Password = "123456", Phone = "(664)467-2145", Birthday = new DateTime(1988, 3, 15), AddressId = 3, Role = "user", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
				new User() { Id = 4, FirstName = "Armando", LastName = "Ortega Partida", Email = "aop@gmail.com", Password = "123456", Phone = "(664)894-4378", Birthday = new DateTime(1952, 8, 21), AddressId = 4, Role = "user", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
				new User() { Id = 5, FirstName = "Patricia", LastName = "Cisneros Mayoral", Email = "patricia@gmail.com", Password = "123456", Phone = "(664)399-1289", Birthday = new DateTime(1963, 9, 15), AddressId = 5, Role = "user", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
			};

			return usersInit;
		}
	}
}

