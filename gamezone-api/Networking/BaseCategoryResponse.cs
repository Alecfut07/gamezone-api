using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public abstract class BaseCategoryResponse
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Handle { get; set; }

        [JsonPropertyName("parent_category_id")]
        public long? ParentCategoryId { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("update_date")]
        public DateTime UpdateDate { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var baseCategoryResponse = obj as BaseCategoryResponse;
            return
                this.Id == baseCategoryResponse.Id &&
                this.Name == baseCategoryResponse.Name &&
                this.Handle == baseCategoryResponse.Handle;
        }
    }
}

