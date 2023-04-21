using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
    public class UserRequest
	{
		[Required]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }
	}
}

