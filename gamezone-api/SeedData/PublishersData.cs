using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class PublishersData
	{
		public static List<Publisher> InitData()
		{
			List<Publisher> publishersInit = new List<Publisher>
			{
				new Publisher() { Id = 1, Name = "Nintendo" },
				new Publisher() { Id = 2, Name = "Sony" },
				new Publisher() { Id = 3, Name = "Microsoft" },
			};

			return publishersInit;
		}
	}
}

