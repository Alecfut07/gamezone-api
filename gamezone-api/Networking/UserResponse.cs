using System;
namespace gamezone_api.Networking
{
	public class UserResponse
	{
		public long Id { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime UpdateDate { get; set; }
	}
}

