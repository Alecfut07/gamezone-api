using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
	public class JwtDenyList
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("jti")]
		public string Jti { get; set; }

		[Column("expiry_date")]
		public DateTime ExpiryDate { get; set; }
	}
}

