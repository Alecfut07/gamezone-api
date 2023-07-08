using System;
using System.Text.Json.Serialization;
using gamezone_api.Models;

namespace gamezone_api.Networking
{
	public class CategoryResponse : BaseCategoryResponse
	{
        [JsonPropertyName("subcategories")]
        public IEnumerable<SubCategoryResponse> SubCategories { get; set; }

        public override bool Equals(object? obj)
        {
            var categoryResponse = obj as CategoryResponse;
            return base.Equals(obj) &&
                this.ParentCategoryId == categoryResponse.ParentCategoryId &&
                this.CreateDate == categoryResponse.CreateDate &&
                this.UpdateDate == categoryResponse.UpdateDate &&
                //this.SubCategories == categoryResponse.SubCategories;
                this.SubCategories.SequenceEqual(categoryResponse.SubCategories);
        }
    }
}

