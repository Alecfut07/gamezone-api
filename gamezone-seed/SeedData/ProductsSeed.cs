using System;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class ProductsSeed
	{
		public static List<Product>? InitData()
		{
			List<Product> productsInit = new List<Product>
			{
				new Product() { Name = "The Legend of Zelda: Ocarina of Time", Description = "Nintendo 64 Game", ReleaseDate = new DateTime(1998, 11, 23), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://coverproject.sfo2.cdn.digitaloceanspaces.com/nintendo_64/n64_zeldaoot_label_thumb.jpg" },
				new Product() { Name = "Tony Hawk''s Pro Skater 2", Description = "PlayStation 1 Game", ReleaseDate = new DateTime(2000, 9, 20), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://coverproject.sfo2.cdn.digitaloceanspaces.com/playstation_1/ps1_tonyhawksproskater2_front_de_thumb.jpg" },
				new Product() { Name = "Grand Theft Auto 4", Description = "PlayStation 3 Game", ReleaseDate = new DateTime(2008, 4, 29), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/81rSkcE4IYL._AC_UF1000,1000_QL80_.jpg" },
				new Product() { Name = "Soul Calibur", Description = "SEGA Dremcast Game", ReleaseDate = new DateTime(1999, 9, 8), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://coverproject.sfo2.cdn.digitaloceanspaces.com/dreamcast/dc_soulcalibur_front_thumb.jpg" },
				new Product() { Name = "Super Mario Galaxy", Description = "Nintendo Wii Game", ReleaseDate = new DateTime(2007, 11, 12), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/51tPCaGMWCL.jpg" },
				new Product() { Name = "Super Mario Galaxy 2", Description = "Nintendo Wii Game", ReleaseDate = new DateTime(2010, 5, 23), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://upload.wikimedia.org/wikipedia/en/6/65/Super_Mario_Galaxy_2_Box_Art.jpg" },
				new Product() { Name = "Red Dead Redemption 2", Description = "Xbox One Game", ReleaseDate = new DateTime(2018, 10, 26), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/81bbAeAG6vS.jpg" },
				new Product() { Name = "Grand Theft Auto 5", Description = "Xbox One Game", ReleaseDate = new DateTime(2014, 11, 18), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://xboxaddict.com/images/box_art/3243.jpg" },
				new Product() { Name = "Disco Elysium: The Final Cut", Description = "PC Game", ReleaseDate = new DateTime(2021, 3, 30), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://gamefaqs.gamespot.com/a/box/4/5/4/793454_front.jpg" },
				new Product() { Name = "The Legend of Zelda: Breath of the Wild", Description = "Nintendo Switch Game", ReleaseDate = new DateTime(2017, 3, 3), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg" },
				new Product() { Name = "Perfect Dark", Description = "Nintendo 64 Game", ReleaseDate = new DateTime(2000, 5, 22), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://i.ebayimg.com/images/g/CegAAOSwn8FXSnIj/s-l500.jpg" },
				new Product() { Name = "Metroid Prime", Description = "Nintendo Gamecube Game", ReleaseDate = new DateTime(2002, 11, 17), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/51NEV04vwQL.jpg" },
				new Product() { Name = "Super Mario Odyssey", Description = "Nintendo Switch Game", ReleaseDate = new DateTime(2017, 10, 27), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/71QevE1u3xL.jpg" },
				new Product() { Name = "Halo: Combat Evolved", Description = "XBOX Game", ReleaseDate = new DateTime(2001, 11, 14), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://pbs.twimg.com/media/FcJiQ3dXEAEFT1B.jpg" },
				new Product() { Name = "NFL 2K1", Description = "SEGA Dreamcast Game", ReleaseDate = new DateTime(2000, 9, 7), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/511HHH8C48L.jpg" },
				new Product() { Name = "Half-Life 2", Description = "PC Game", ReleaseDate = new DateTime(2004, 11, 16), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/2/25/Half-Life_2_cover.jpg/220px-Half-Life_2_cover.jpg" },
				new Product() { Name = "BioShock", Description = "Xbox 360 Game", ReleaseDate = new DateTime(2007, 8, 21), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://store-images.s-microsoft.com/image/apps.35693.67628702173327834.9631ebfc-9c57-41b2-b688-4acf5b3815ce.ad223159-35ee-40ef-983b-58be333febbc?q=90&w=177&h=177" },
				new Product() { Name = "GoldenEye 007", Description = "Nintendo 64 Game", ReleaseDate = new DateTime(1997, 8, 25), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://upload.wikimedia.org/wikipedia/en/3/36/GoldenEye007box.jpg" },
				new Product() { Name = "Uncharted 2: Among Thieves", Description = "PlayStation 3 Game", ReleaseDate = new DateTime(2009, 10, 13), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/61bfoo-Z9cL.jpg" },
				new Product() { Name = "Resident Evil 4", Description = "Nintendo Gamecube Game", ReleaseDate = new DateTime(2005, 1, 11), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://upload.wikimedia.org/wikipedia/en/d/d9/Resi4-gc-cover.jpg" },
				new Product() { Name = "Batman: Arkham City", Description = "PlayStation 3 Game", ReleaseDate = new DateTime(2011, 10, 18), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://1.bp.blogspot.com/-RaTxp5ajcNc/TfpQ50ApvCI/AAAAAAAAFkQ/AIjaHa9mdJQ/s1600/Arkham-City-PS3-Cover-Artwork_5.jpg" },
				new Product() { Name = "Tekken 3", Description = "PlayStation 1 Game", ReleaseDate = new DateTime(1998, 4, 29), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/61Gz1FccqGL._SX522_.jpg" },
				new Product() { Name = "Elden Ring", Description = "Xbox Series X Game", ReleaseDate = new DateTime(2022, 2, 25), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/81AXuMBqy9L._AC_UF1000,1000_QL80_.jpg" },
				new Product() { Name = "Mass Effect 2", Description = "Xbox 360 Game", ReleaseDate = new DateTime(2010, 1, 26), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://i.ebayimg.com/images/g/JJMAAOSwHZhhYTPc/s-l1600.jpg" },
				new Product() { Name = "The Legend of Zelda: Twilight Princess", Description = "Nintendo Gamecube Game", ReleaseDate = new DateTime(2006, 12, 11), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/51I25VxTAfL.jpg" },
				new Product() { Name = "The Elder Scrolls 5: Skyrim", Description = "Xbox 360 Game", ReleaseDate = new DateTime(2011, 11, 11), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/91nOykIoY3L.jpg" },
				new Product() { Name = "The Legend of Zelda: The Wind Waker", Description = "Nintendo Gamecube Game", ReleaseDate = new DateTime(2003, 3, 24), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://wiki.dolphin-emu.org/images/9/98/Wind_waker_boxart.jpg" },
				new Product() { Name = "Gran Turismo", Description = "PlayStation 1 Game", ReleaseDate = new DateTime(1998, 4, 30), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://i.ebayimg.com/images/g/05YAAOSwlxRaaLU5/s-l300.jpg" },
				new Product() { Name = "Metal Gear Solid 2: Sons of Liberty", Description = "PlayStation 2 Game", ReleaseDate = new DateTime(2001, 11, 12), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://cdn.staticneo.com/boxshots/MjAwNS8=/metal_gear_solid_2_sons_of_liberty_frontcover_large_NICQvk5nPZUjp8Y.jpg" },
				new Product() { Name = "Persona 5 Royal", Description = "Nintendo Switch Game", ReleaseDate = new DateTime(2022, 10, 21), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/81qu57lDKpL.jpg" },
				new Product() { Name = "Call of Duty: Modern Warfare II", Description = "PlayStation 5 Game", ReleaseDate = new DateTime(2022, 10, 28), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://media.gamestop.com/i/gamestop/11206901-11206901" },
				new Product() { Name = "Call of Duty: Modern Warfare II", Description = "PlayStation 4 Game", ReleaseDate = new DateTime(2022, 10, 28), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://media.gamestop.com/i/gamestop/11206901-11206900" },
				new Product() { Name = "Call of Duty: Modern Warfare II", Description = "Xbox Series X", ReleaseDate = new DateTime(2022, 10, 28), CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ImageURL = "https://m.media-amazon.com/images/I/81YeBLA3U4L._AC_UF1000,1000_QL80_.jpg" },
			};
			return productsInit;
		}
	}
}

