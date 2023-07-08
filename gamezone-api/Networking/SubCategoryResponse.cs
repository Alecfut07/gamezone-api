using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class SubCategoryResponse : BaseCategoryResponse
	{
        [JsonPropertyName("parent_category_id")]
        public long? ParentCategoryId { get; set; }

        public override bool Equals(object? obj)
        {
            var subcategoryResponse = obj as SubCategoryResponse;
            return base.Equals(obj) &&
                this.CreateDate == subcategoryResponse.CreateDate &&
                this.UpdateDate == subcategoryResponse.UpdateDate &&
                this.ParentCategoryId == subcategoryResponse.ParentCategoryId;
        }
    }
}

