using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class UserRequest
	{
		[Required]
		public string Email { get; set; }

		[Required]
        [JsonPropertyName("encrypted_password")]
        public string Password { get; set; }
	}
}

