using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace gamezone_api.Models.Stripe
{
    //public record Customer(string Email, string Name, CreditCard CreditCard);

    public class Customer
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("credit_card")]
        public CreditCard CreditCard { get; set; }
    }
}

