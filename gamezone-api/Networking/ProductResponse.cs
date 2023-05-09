using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class ProductResponse
    {
        public long Id { get; set; }

        [JsonPropertyName("image_url")]
        public string? ImageURL { get; set; }

        public string Name { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        public string? Description { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("update_date")]
        public DateTime UpdateDate { get; set; }

        [JsonPropertyName("product_variants")]
        public ICollection<ProductVariantResponse> ProductVariantResponses { get; set; }
    }
}
