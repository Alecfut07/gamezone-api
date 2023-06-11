using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class OrderResponse
	{
		public Guid Id { get; set; }

        [JsonPropertyName("user_id")]
        public long? UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("grandtotal")]
        public decimal Grandtotal { get; set; }

        [JsonPropertyName("order_details")]
        public ICollection<OrderDetailResponse> OrderDetailsResponses { get; set; }
    }
}

