using System;
using System.Text.Json.Serialization;
using gamezone_api.Models;

namespace gamezone_api.Networking
{
	public class CategoryResponse : BaseCategoryResponse
	{
        [JsonPropertyName("subcategories")]
        public IEnumerable<SubCategoryResponse> SubCategories { get; set; }
    }
}

