using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class OrderDetailRequest
	{
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        //[Required]
        [JsonPropertyName("order_id")]
        public Guid OrderId { get; set; }

        [Required]
        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        //[Required]
        [JsonPropertyName("tax")]
        public decimal Tax { get; set; }

        [Required]
        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [Required]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [Required]
        [JsonPropertyName("grandtotal")]
        public decimal Grandtotal { get; set; }

        [Required]
        [JsonPropertyName("product_id")]
        public long ProductId { get; set; }
	}
}

