﻿using System;
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

        public void DeleteData()
        {
            foreach (var item in _context.Categories)
            {
                _context.Categories.Remove(item);
            }
            _context.SaveChanges();
        }
	}
}

