using System;
using System.Text.Json.Serialization;
using gamezone_api.Models;

namespace gamezone_api.Networking
{
	public class CartResponse
	{
		[JsonPropertyName("products")]
		public ICollection<CartProduct> Products { get; set; }
	}
}
