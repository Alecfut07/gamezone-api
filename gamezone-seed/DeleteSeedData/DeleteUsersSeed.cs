using System;
using gamezone_api;

namespace gamezone_seed.DeleteSeedData
{
	public class DeleteUsersSeed
	{
        private readonly GamezoneContext _context;

        public DeleteUsersSeed(GamezoneContext context)
        {
            _context = context;
        }

        public void DeleteData()
        {
            foreach (var item in _context.Users)
            {
                _context.Users.Remove(item);
            }
            _context.SaveChanges();
        }
	}
}

