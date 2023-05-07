using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class UserResponse
	{
		public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

		public string Email { get; set; }

		public string Phone { get; set; }

		public DateTime? Birthday { get; set; }

        [JsonPropertyName("address")]
        public AddressResponse AddressResponse { get; set; }

        public string Role { get; set; }

        [JsonPropertyName("create_date")]
        public DateTime CreateDate { get; set; }

        [JsonPropertyName("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}

