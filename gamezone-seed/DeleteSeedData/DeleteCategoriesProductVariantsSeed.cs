using System;
using gamezone_api;

namespace gamezone_seed.DeleteSeedData
{
	public class DeleteCategoriesProductVariantsSeed
	{
        private readonly GamezoneContext _context;

        public DeleteCategoriesProductVariantsSeed(GamezoneContext context)
        {
            _context = context;
        }

        public void DeleteData()
        {
            foreach (var item in _context.CategoriesProductVariants)
            {
                _context.CategoriesProductVariants.Remove(item);
            }
            _context.SaveChanges();
        }
	}
}

