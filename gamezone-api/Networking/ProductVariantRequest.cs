using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class ProductVariantRequest
	{
		[Required]
		public decimal Price { get; set; }

        [Required]
        [JsonPropertyName("condition_id")]
        public int ConditionId { get; set; }

        [Required]
        [JsonPropertyName("edition_id")]
        public int EditionId { get; set; }
    }
}

