using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class AddressResponse
	{
		public long Id { get; set; }

		public string Line1 { get; set; }

		public string Line2 { get; set; }

        [JsonPropertyName("zip_code")]
        public string ZipCode { get; set; }

		public string State { get; set; }

		public string City { get; set; }

		public string Country { get; set; }
	}
}

