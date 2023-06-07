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
				Handle = categoryRequest.Handle,
				ParentCategoryId = categoryRequest.ParentCategoryId
			};
		}

		public List<CategoryResponse> Map(Dictionary<Category, List<Category>> categoriesDictionary)
		{
			return categoriesDictionary.Select(entry => Map(entry.Key, entry.Value)).ToList();
		}

		public CategoryResponse Map(Category category, List<Category> subcategories)
		{
			return new CategoryResponse
			{
				Id = category.Id,
				Name = category.Name,
				Handle = category.Handle,
				CreateDate = category.CreateDate,
				UpdateDate = category.UpdateDate,
				ParentCategoryId = category.ParentCategoryId,
				SubCategories = subcategories.ConvertAll(subcategory => Map(subcategory))
			};
		}

		public SubCategoryResponse Map(Category subcategory)
		{
			var subcategoryResponse = new SubCategoryResponse
			{
				Id = subcategory.Id,
				Name = subcategory.Name,
				Handle = subcategory.Handle,
                CreateDate = subcategory.CreateDate,
                UpdateDate = subcategory.UpdateDate,
                ParentCategoryId = subcategory.ParentCategoryId
            };
			return subcategoryResponse;
		}
	}
}

