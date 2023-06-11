using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Models.Stripe
{
    //public record CreditCard(string Name, string CardNumber, string ExpirationYear, string ExpirationMonth, string Cvc);

    public class CreditCard
    {
        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("card_number")]
        public string CardNumber { get; set; }

        [JsonPropertyName("expiration_month")]
        public string ExpirationMonth { get; set; }

        [JsonPropertyName("expiration_year")]
        public string ExpirationYear { get; set; }

        [JsonPropertyName("cvc")]
        public string Cvc { get; set; }
    }
}

