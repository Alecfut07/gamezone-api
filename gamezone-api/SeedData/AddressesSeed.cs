using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class AddressesSeed
	{
		public static List<Address> InitData()
		{
			List<Address> addressesInit = new List<Address>
			{
				new Address() { Id = 1, Line1 = "7700 S Broadway, Littleton", Line2 = "", ZipCode = "80122", State = "CO", City = "Denver", Country = "United States" }, 
				new Address() { Id = 2, Line1 = "5460 S Broadway, Englewood", Line2 = "", ZipCode = "80113", State = "CO", City = "Denver", Country = "United States" }, 
				new Address() { Id = 3, Line1 = "435 H St, Chula Vista", Line2 = "", ZipCode = "91910", State = "CA", City = "San Diego", Country = "United States" }, 
				new Address() { Id = 4, Line1 = "500 Hotel Cir N, San Diego", Line2 = "Room 10", ZipCode = "92108", State = "CA", City = "San Diego", Country = "United States" }, 
				new Address() { Id = 5, Line1 = "5998 Alcala Park Way, San Diego", Line2 = "", ZipCode = "92110", State = "CA", City = "San Diego", Country = "United States" }, 
			};

			return addressesInit;
		}
	}
}

