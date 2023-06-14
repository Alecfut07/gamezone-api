using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class SubCategoriesSeed
	{
        private readonly GamezoneContext _context;

        public SubCategoriesSeed(GamezoneContext context)
        {
            _context = context;
        }

        public List<Category>? InitData()
        {
            var categoryVideogamesId = _context.Categories.Where(c => c.Name == "Video Games").Select(c => c.Id).SingleOrDefault();
            var categoryConsolesHardwareId = _context.Categories.Where(c => c.Name == "Consoles & Hardware").Select(c => c.Id).SingleOrDefault();
            var categoryGamingAccessoriesId = _context.Categories.Where(c => c.Name == "Gaming Accessories").Select(c => c.Id).SingleOrDefault();

            List<Category> subCateogiresInit = new List<Category>
            {
                // Subcategories of Video Games.
                new Category() { Name = "PC", Handle = "pc", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "Xbox Series X | S", Handle = "xbox-series-x-s", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "Xbox One", Handle = "xbox-one", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "PlayStation 5", Handle = "playstation-5", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "PlayStation 4", Handle = "playstation-4", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "Nintendo Switch", Handle = "nintendo-switch", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },
                new Category() { Name = "Retro Gaming", Handle = "retro-gaming", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryVideogamesId },

                // Subcategories of Consoles & Hardware.
                new Category() { Name = "Xbox Series X | S", Handle = "xbox-series-x-s", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "Xbox One", Handle = "xbox-one", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "PlayStation 5", Handle = "playstation-5", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "PlayStation 4", Handle = "playstation-4", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "Nintendo Switch", Handle = "nintendo-switch", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "Retro Gaming", Handle = "retro-gaming", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "Virtual Reality", Handle = "virtual-reality", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },
                new Category() { Name = "Arcade", Handle = "arcade", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryConsolesHardwareId },

                // Subcategories of Gaming Accessories.
                new Category() { Name = "Cases & Stands", Handle = "cases-stands", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Chargers & Cables", Handle = "chargers-cables", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Controllers", Handle = "controllers", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Gaming Headsets", Handle = "gaming-headsets", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Memory", Handle = "memory", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Mounts", Handle = "mounts", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Screen Protectors", Handle = "screen-protectors", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
                new Category() { Name = "Thumb Grips", Handle = "thumb-grips", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = categoryGamingAccessoriesId },
            };
            return subCateogiresInit;
        }
    }
}

