using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class ProductRequest
	{
        [JsonPropertyName("image_url")]
        public string ImageURL { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [JsonPropertyName("release_date")]
        public DateTime? ReleaseDate { get; set; }

        public string? Description { get; set; }

        [Required]
        [JsonPropertyName("condition_id")]
        public int ConditionId { get; set; }

        [Required]
        [JsonPropertyName("edition_id")]
        public int EditionId { get; set; }
    }
}

