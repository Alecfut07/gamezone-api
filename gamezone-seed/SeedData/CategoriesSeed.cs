using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.SeedData
{
	public class CategoriesSeed
	{
        private readonly GamezoneContext _context;

        public CategoriesSeed(GamezoneContext context)
        {
            _context = context;
        }

        public static List<Category>? InitData()
        {
            List<Category> cateogiresInit = new List<Category>
            {
                new Category() { Name = "Video Games", Handle = "video-games", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = null },
                new Category() { Name = "Consoles & Hardware", Handle = "consoles-hardware", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = null },
                new Category() { Name = "Gaming Accessories", Handle = "gaming-accessories", CreateDate = DateTime.Now, UpdateDate = DateTime.Now, ParentCategoryId = null },
            };
            return cateogiresInit;
        }
    }
}

