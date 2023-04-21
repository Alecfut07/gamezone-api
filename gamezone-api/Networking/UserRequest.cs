using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
    public class UserRequest
	{
		[Required]
		public string Email { get; set; }

		[Required]
		[StringLength(20, MinimumLength = 6, ErrorMessage = "The password is too short.")]
        public string Password { get; set; }
	}
}

