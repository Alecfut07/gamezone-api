using System;
using System.Text.Json.Serialization;
using gamezone_api.Models;
using gamezone_api.Models.Stripe;

namespace gamezone_api.Networking
{
	public class OrderRequest
	{
        [JsonPropertyName("customer")]
        public Customer Customer { get; set; }

        [JsonPropertyName("address")]
        public AddressRequest Address { get; set; }

        [JsonPropertyName("payment")]
        public Payment Payment { get; set; }

        [JsonPropertyName("order_details")]
        public ICollection<OrderDetailRequest> OrderDetailRequests { get; set; }
    }
}

