using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class ProductRequest
	{
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

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

