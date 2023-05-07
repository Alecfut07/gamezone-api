using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class User
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("first_name")]
		public string FirstName { get; set; }

		[Column("last_name")]
		public string LastName { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[Column("encrypted_password")]
		public string Password { get; set; }

		[Column("phone")]
		public string Phone { get; set; }

		[Column("birthday")]
		public DateTime? Birthdate { get; set; }

		[ForeignKey("address_id")]
		[Column("address_id")]
		public long? AddressId { get; set; }

		[Column("create_date")]
		public DateTime CreateDate { get; set; }

		[Column("update_date")]
		public DateTime UpdateDate { get; set; }

		public Address? Address { get; set; }
	}
}

