using System;
namespace gamezone_api.Models
{
	public class CartProduct
	{
		public long ProductId { get; set; }

		public string Name { get; set; }

		public double Price { get; set; }

		public int Quantity { get; set; }
	}
}

