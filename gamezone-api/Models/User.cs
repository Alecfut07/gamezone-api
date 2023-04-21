using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class User
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("encrypted_password")]
		public string Password { get; set; }

		[Column("create_date")]
		public DateTime CreateDate { get; set; }

		[Column("update_date")]
		public DateTime UpdateDate { get; set; }
	}
}

