using System;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class CategoryService : ICategoryService
	{
		private CategoriesRepository categoriesRepository;

		public CategoryService(CategoriesRepository categoriesRepository)
		{
			this.categoriesRepository = categoriesRepository;
		}

		public async Task<IEnumerable<CategoryResponse>> GetCategories()
		{
			var categories = await categoriesRepository.GetCategories();
			return categories;
		}
	}

	public interface ICategoryService
	{
		Task<IEnumerable<CategoryResponse>> GetCategories();
	}
}

