using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class ProductsSeed
	{
		public static List<Product> InitData()
		{
			List<Product> productsInit = new List<Product>
			{
                new Product() { Id = 1, Name = "The Legend of Zelda: Ocarina of Time", ReleaseDate = new DateTime(1998, 11, 23), Description = "Nintendo 64 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 2, Name = "Tony Hawk's Pro Skater 2", ReleaseDate = new DateTime(2000, 9, 20), Description = "PlayStation 1 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 3, Name = "Grand Theft Auto 4", ReleaseDate = new DateTime(2008, 4, 29), Description = "PlayStation 3 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 4, Name = "Soul Calibur", ReleaseDate = new DateTime(1999, 9, 8), Description = "SEGA Dreamcast Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 5, Name = "Super Mario Galaxy", ReleaseDate = new DateTime(2007, 11, 12), Description = "Nintendo Wii Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 6, Name = "Super Mario Galaxy 2", ReleaseDate = new DateTime(2010, 5, 23), Description = "Nintendo Wii Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 7, Name = "Read Dead Redemption 2", ReleaseDate = new DateTime(2018, 10, 26), Description = "Xbox One Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 8, Name = "Grand Theft Auto 5", ReleaseDate = new DateTime(2014, 11, 18), Description = "Xbox One Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 9, Name = "Disco Elysium: The Final Cut", ReleaseDate = new DateTime(2021, 3, 30), Description = "PC Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 10, Name = "The Legend of Zelda: Breath of the Wild", ReleaseDate = new DateTime(2017, 3, 3), Description = "Nintendo Switch Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 11, Name = "Perfect Dark", ReleaseDate = new DateTime(2000, 5, 22), Description = "Nintendo 64 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 12, Name = "Metroid Prime", ReleaseDate = new DateTime(2002, 11, 17), Description = "Nintendo Gamecube Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 13, Name = "Super Mario Odyssey", ReleaseDate = new DateTime(2017, 10, 27), Description = "Nintendo Switch Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 14, Name = "Halo: Combat Evolved", ReleaseDate = new DateTime(2001, 11, 14), Description = "Nintendo Switch Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 15, Name = "NFL 2K1", ReleaseDate = new DateTime(2000, 9, 7), Description = "SEGA Dreamcast", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 16, Name = "Half-Life 2", ReleaseDate = new DateTime(2004, 11, 16), Description = "PC Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 17, Name = "BioSchock", ReleaseDate = new DateTime(2007, 8, 21), Description = "Xbox 360 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 18, Name = "GoldenEye 007", ReleaseDate = new DateTime(1997, 8, 25), Description = "Nintendo 64 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 19, Name = "Uncharted 2: Among Thieves", ReleaseDate = new DateTime(2009, 10, 13), Description = "PlayStation 3 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 20, Name = "Resident Evil 4", ReleaseDate = new DateTime(2005, 1, 11), Description = "Nintendo Gamecube Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 21, Name = "Batman: Arkham City", ReleaseDate = new DateTime(2011, 10, 18), Description = "PlayStation 3 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 22, Name = "Tekken 3", ReleaseDate = new DateTime(1998, 4, 29), Description = "PlayStation 1 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 23, Name = "Elden Ring", ReleaseDate = new DateTime(2022, 2, 25), Description = "Xbox Series X Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 24, Name = "Mass Effect 2", ReleaseDate = new DateTime(2010, 1, 26), Description = "Xbox 360 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 25, Name = "The Legend of Zelda: Twilight Princess", ReleaseDate = new DateTime(2006, 12, 11), Description = "Nintendo Gamecube Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 26, Name = "The Elder Scrolls 5: Skyrim", ReleaseDate = new DateTime(2011, 11, 11), Description = "Xbox 360 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 27, Name = "The Legend of Zelda: The Wind Waker", ReleaseDate = new DateTime(2003, 3, 24), Description = "Nintendo Gamecube Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 28, Name = "Gran Turismo", ReleaseDate = new DateTime(1998, 4, 30), Description = "PlayStation 1 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 29, Name = "Metal Gear Solid 2: Sons of Liberty", ReleaseDate = new DateTime(2001, 11, 12), Description = "PlayStation 2 Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
                new Product() { Id = 30, Name = "Persona 5 Royal", ReleaseDate = new DateTime(2022, 10, 21), Description = "Nintendo Switch Game", CreateDate = DateTime.Now, UpdateDate = DateTime.Now },
            };

			return productsInit;
		}
	}
}

