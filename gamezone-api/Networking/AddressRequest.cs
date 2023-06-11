using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class AddressRequest
	{
		[Required]
		[JsonPropertyName("line_1")]
		public string Line1 { get; set; }

		[JsonPropertyName("line_2")]
		public string? Line2 { get; set; }

		[Required]
        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

		[Required]
		[JsonPropertyName("state")]
		public string State { get; set; }

		[Required]
		[JsonPropertyName("city")]
		public string City { get; set; }

		[Required]
		[JsonPropertyName("country")]
		public string Country { get; set; }
	}
}

