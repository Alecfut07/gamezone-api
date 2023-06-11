using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
	public class Order
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Column("tax")]
		public decimal Tax { get; set; }

		[Column("subtotal")]
		public decimal Subtotal { get; set; }

		[Column("grandtotal")]
		public decimal Grandtotal { get; set; }

		[Column("email")]
		public string Email { get; set; }

		[ForeignKey("user_id")]
		[Column("user_id")]
		public long? UserId { get; set; }

		public virtual User User { get; set; }
	}
}

