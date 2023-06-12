using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gamezone_api.Models
{
	public class OrderDetail
	{
		[Key]
		[Column("id")]
		public Guid Id { get; set; }

		[Column("price")]
		public decimal Price { get; set; }

        [Column("subtotal")]
        public decimal Subtotal { get; set; }

        [Column("tax")]
        public decimal Tax { get; set; }

		[Column("grandtotal")]
		public decimal Grandtotal { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [ForeignKey("order_id")]
		[Column("order_id")]
		public Guid OrderId { get; set; }

        [ForeignKey("product_id")]
		[Column("product_id")]
		public long ProductId { get; set; }

		public virtual Order Order { get; set; }

		public virtual Product Product { get; set; }

	}
}

