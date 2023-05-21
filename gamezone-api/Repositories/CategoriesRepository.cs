using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class CategoriesRepository
	{
		private GamezoneContext context;
		private CategoriesMapper categoriesMapper;

		public CategoriesRepository(GamezoneContext dbContext, CategoriesMapper categoriesMapper)
		{
			context = dbContext;
			this.categoriesMapper = categoriesMapper;
		}

		public async Task<IEnumerable<CategoryResponse>> GetCategories()
		{
			var categories = await context.Categories.ToListAsync();

			var categoriesResponse = categories.ConvertAll<CategoryResponse>((c) => categoriesMapper.Map(c));
			return categoriesResponse;
		}
	}
}

