using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class OrderDetailResponse
	{
		public Guid Id { get; set; }

        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("grandtotal")]
        public decimal Grandtotal { get; set; }

        public virtual OrderResponse Order { get; set; }

        public virtual ProductResponse Product { get; set; }
    }
}

