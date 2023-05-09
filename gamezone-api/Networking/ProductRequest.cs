using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class ProductRequest
	{
        [JsonPropertyName("image_url")]
        public string ImageURL { get; set; }

        [JsonPropertyName("image_key")]
        public string ImageKey { get; set; }

        [Required]
        public string Name { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        public string? Description { get; set; }

        [JsonPropertyName("product_variants")]
        public ICollection<ProductVariantRequest> ProductVariantRequests { get; set; } 
    }
}

