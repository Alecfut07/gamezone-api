using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public abstract class BaseCategoryResponse
	{
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}

