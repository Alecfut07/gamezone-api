﻿using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class ProductVariantsSeed
	{
		public static List<ProductVariant> InitData()
		{
			List<ProductVariant> productVariantsInit = new List<ProductVariant>
			{
				new ProductVariant() { Id = 1, Price = 10.20M, ProductId = 1, ConditionId = 1, EditionId = 1 },
				new ProductVariant() { Id = 2, Price = 15.10M, ProductId = 2, ConditionId = 1, EditionId = 2 },
				new ProductVariant() { Id = 3, Price = 5.12M, ProductId = 3, ConditionId = 1, EditionId = 3 },
				new ProductVariant() { Id = 4, Price = 40.22M, ProductId = 4, ConditionId = 2, EditionId = 1 },
				new ProductVariant() { Id = 5, Price = 32.25M, ProductId = 5, ConditionId = 2, EditionId = 2 },
				new ProductVariant() { Id = 6, Price = 12.11M, ProductId = 6, ConditionId = 2, EditionId = 3 },
				new ProductVariant() { Id = 7, Price = 2.02M, ProductId = 7, ConditionId = 3, EditionId = 1 },
				new ProductVariant() { Id = 8, Price = 11.11M, ProductId = 8, ConditionId = 3, EditionId = 2 },
				new ProductVariant() { Id = 9, Price = 3.33M, ProductId = 9, ConditionId = 3, EditionId = 3 },
				new ProductVariant() { Id = 10, Price = 31.31M, ProductId = 10, ConditionId = 1, EditionId = 1 },
				new ProductVariant() { Id = 11, Price = 60M, ProductId = 11, ConditionId = 2, EditionId = 1 },
				new ProductVariant() { Id = 12, Price = 21M, ProductId = 12, ConditionId = 3, EditionId = 1 },
				new ProductVariant() { Id = 13, Price = 10.01M, ProductId = 13, ConditionId = 1, EditionId = 2 },
				new ProductVariant() { Id = 14, Price = 9M, ProductId = 14, ConditionId = 2, EditionId = 2 },
				new ProductVariant() { Id = 15, Price = 2M, ProductId = 15, ConditionId = 3, EditionId = 2 },
				new ProductVariant() { Id = 16, Price = 45.21M, ProductId = 16, ConditionId = 1, EditionId = 3 },
				new ProductVariant() { Id = 17, Price = 40.04M, ProductId = 17, ConditionId = 2, EditionId = 3 },
				new ProductVariant() { Id = 18, Price = 12.43M, ProductId = 18, ConditionId = 3, EditionId = 3 },
				new ProductVariant() { Id = 19, Price = 7.07M, ProductId = 19, ConditionId = 1, EditionId = 2 },
				new ProductVariant() { Id = 20, Price = 4.31M, ProductId = 20, ConditionId = 1, EditionId = 3 },
				new ProductVariant() { Id = 21, Price = 6.50M, ProductId = 21, ConditionId = 2, EditionId = 1 },
				new ProductVariant() { Id = 22, Price = 17.90M, ProductId = 22, ConditionId = 2, EditionId = 3 },
				new ProductVariant() { Id = 23, Price = 27M, ProductId = 23, ConditionId = 3, EditionId = 1 },
				new ProductVariant() { Id = 24, Price = 30.08M, ProductId = 24, ConditionId = 3, EditionId = 2 },
				new ProductVariant() { Id = 25, Price = 41.14M, ProductId = 25, ConditionId = 3, EditionId = 2 },
				new ProductVariant() { Id = 26, Price = 18.89M, ProductId = 26, ConditionId = 3, EditionId = 1 },
				new ProductVariant() { Id = 27, Price = 55M, ProductId = 27, ConditionId = 2, EditionId = 3 },
				new ProductVariant() { Id = 28, Price = 5M, ProductId = 28, ConditionId = 2, EditionId = 1 },
				new ProductVariant() { Id = 29, Price = 46.72M, ProductId = 29, ConditionId = 1, EditionId = 3 },
				new ProductVariant() { Id = 30, Price = 60M, ProductId = 30, ConditionId = 1, EditionId = 2 },
			};

			return productVariantsInit;
		}
	}
}

