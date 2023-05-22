using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class CategoriesMapper
	{
		public Category Map(CategoryRequest categoryRequest)
		{
			return new Category
			{
				Name = categoryRequest.Name
			};
		}

		public CategoryResponse Map(Category category)
		{
			return new CategoryResponse
			{
				Id = category.Id,
				Name = category.Name
			};
		}
	}
}

