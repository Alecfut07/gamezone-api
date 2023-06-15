using System;
using gamezone_api;

namespace gamezone_seed.DeleteSeedData
{
	public class DeleteProductsSeed
	{
        private readonly GamezoneContext _context;

        public DeleteProductsSeed(GamezoneContext context)
        {
            _context = context;
        }

        public void DeleteData()
        {
            foreach (var item in _context.Products)
            {
                _context.Products.Remove(item);
            }
            _context.SaveChanges();
        }
	}
}

