using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class UserRequest
	{
        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [Required]
		public string Email { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "The password is too short.")]
		public string Password { get; set; }

        public string Phone { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}

