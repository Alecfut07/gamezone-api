﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using gamezone_api.Models;

namespace gamezone_api.Networking
{
	public class ProductVariantResponse
	{
        public long Id { get; set; }

        public decimal Price { get; set; }

        public virtual ConditionResponse Condition { get; set; }

        public virtual EditionResponse Edition { get; set; }

        [JsonPropertyName("categories")]
        public ICollection<CategoryProductVariantResponse> CategoriesResponses { get; set; }
    }
}

