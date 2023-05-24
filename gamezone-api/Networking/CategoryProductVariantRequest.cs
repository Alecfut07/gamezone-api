using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class CategoryProductVariantRequest
	{
		public long Id { get; set; }

        [Required]
        [JsonPropertyName("category_id")]
        public long CategoryProductVariantId { get; set; }
    }
}

