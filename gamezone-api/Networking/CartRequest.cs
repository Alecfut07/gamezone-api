using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class CartRequest
	{
		[JsonPropertyName("product_id")]
		public long ProductId { get; set; }

		public int Quantity { get; set; }
	}
}

