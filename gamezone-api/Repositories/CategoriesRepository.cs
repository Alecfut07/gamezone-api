using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class CategoriesRepository
	{
		private GamezoneContext _context;

		public CategoriesRepository(GamezoneContext dbContext)
		{
			_context = dbContext;
		}

		public async Task<List<Category>> GetCategories()
		{
			var categories = await _context.Categories.ToListAsync();
			return categories;
		}

		public async Task<Category?> GetCategoryById(long id)
		{
			var category = await _context.Categories.FindAsync(id);
			return category;
		}

		public async Task<Category> CreateNewCategory(Category category)
		{
			_context.Categories.Add(category);
			await _context.SaveChangesAsync();

			var newCategory = await _context.Categories.SingleAsync(c => c.Id == category.Id);
			return newCategory;
		}

		public async Task<Category?> UpdateCategory(long id, Category category)
		{
			var result = await _context.Categories
				.Where((c) => c.Id == id)
				.ExecuteUpdateAsync((cate) =>
					cate
						.SetProperty((c) => c.Name, category.Name)
						);

			if (result > 0)
			{
				var updatedCategory = await _context.Categories.FindAsync(id);
				return updatedCategory;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public async Task DeleteCategory(long id)
		{
			var categoryToDelete = await _context.Categories.FindAsync(id);

			if (categoryToDelete == null)
			{
				throw new KeyNotFoundException();
			}
			else
			{
				_context.Categories.Remove(categoryToDelete);
				await _context.SaveChangesAsync();
			}
		}
	}
}

