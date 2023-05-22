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
				Name = categoryRequest.Name,
				ParentCategoryId = categoryRequest.ParentCategoryId
			};
		}

		public CategoryResponse Map(Category category)
		{
			return new CategoryResponse
			{
				Id = category.Id,
				Name = category.Name,
				CreateDate = category.CreateDate,
				UpdateDate = category.UpdateDate,
				ParentCategoryId = category.ParentCategoryId
			};
		}
	}
}

