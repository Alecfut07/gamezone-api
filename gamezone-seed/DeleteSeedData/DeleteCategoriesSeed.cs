using System;
using gamezone_api;
using gamezone_api.Models;

namespace gamezone_seed.DeleteSeedData
{
	public class DeleteCategoriesSeed
	{
        private readonly GamezoneContext _context;

        public DeleteCategoriesSeed(GamezoneContext context)
        {
            _context = context;
        }

        public List<Category> DeleteData()
        {
            var categoriesIds = _context.Categories.Select(c => new Category { Id = c.Id }).ToList();
            return categoriesIds;
        }
	}
}

