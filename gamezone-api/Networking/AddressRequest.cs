using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class AddressRequest
	{
		[Required]
		public string Line1 { get; set; }

		public string Line2 { get; set; }

		[Required]
        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

		[Required]
		public string State { get; set; }

		[Required]
		public string City { get; set; }

		[Required]
		public string Country { get; set; }
	}
}

