using System;
using gamezone_api;

namespace gamezone_seed.DeleteSeedData
{
	public class DeleteProductVariantsSeed
	{
        private readonly GamezoneContext _context;

        public DeleteProductVariantsSeed(GamezoneContext context)
        {
            _context = context;
        }

        public void DeleteData()
        {
            foreach (var item in _context.ProductVariants)
            {
                _context.ProductVariants.Remove(item);
            }
            _context.SaveChanges();
        }
	}
}

