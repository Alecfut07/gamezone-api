using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class SubCategoryResponse : BaseCategoryResponse
	{
        [JsonPropertyName("parent_category_id")]
        public long? ParentCategoryId { get; set; }
    }
}

