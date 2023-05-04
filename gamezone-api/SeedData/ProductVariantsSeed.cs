using System;
using gamezone_api.Models;

namespace gamezone_api.SeedData
{
	public class ProductVariantsSeed
	{
		public static List<ProductVariants> InitData()
		{
			List<ProductVariants> productVariantsInit = new List<ProductVariants>
			{
				new ProductVariants() { Id = 1, Price = 10.20M, ProductId = 1, ConditionId = 1, EditionId = 1 },
				new ProductVariants() { Id = 2, Price = 10.20M, ProductId = 2, ConditionId = 1, EditionId = 2 },
				new ProductVariants() { Id = 3, Price = 10.20M, ProductId = 3, ConditionId = 1, EditionId = 3 },
				new ProductVariants() { Id = 4, Price = 10.20M, ProductId = 4, ConditionId = 2, EditionId = 1 },
				new ProductVariants() { Id = 5, Price = 10.20M, ProductId = 5, ConditionId = 2, EditionId = 2 },
				new ProductVariants() { Id = 6, Price = 10.20M, ProductId = 6, ConditionId = 2, EditionId = 3 },
				new ProductVariants() { Id = 7, Price = 10.20M, ProductId = 7, ConditionId = 3, EditionId = 1 },
				new ProductVariants() { Id = 8, Price = 10.20M, ProductId = 8, ConditionId = 3, EditionId = 2 },
				new ProductVariants() { Id = 9, Price = 10.20M, ProductId = 9, ConditionId = 3, EditionId = 3 },
				new ProductVariants() { Id = 10, Price = 10.20M, ProductId = 10, ConditionId = 1, EditionId = 1 },
				new ProductVariants() { Id = 11, Price = 10.20M, ProductId = 11, ConditionId = 2, EditionId = 1 },
				new ProductVariants() { Id = 12, Price = 10.20M, ProductId = 12, ConditionId = 3, EditionId = 1 },
				new ProductVariants() { Id = 13, Price = 10.20M, ProductId = 13, ConditionId = 1, EditionId = 2 },
				new ProductVariants() { Id = 14, Price = 10.20M, ProductId = 14, ConditionId = 2, EditionId = 2 },
				new ProductVariants() { Id = 15, Price = 10.20M, ProductId = 15, ConditionId = 3, EditionId = 2 },
				new ProductVariants() { Id = 16, Price = 10.20M, ProductId = 16, ConditionId = 1, EditionId = 3 },
				new ProductVariants() { Id = 17, Price = 10.20M, ProductId = 17, ConditionId = 2, EditionId = 3 },
				new ProductVariants() { Id = 18, Price = 10.20M, ProductId = 18, ConditionId = 3, EditionId = 3 },
				new ProductVariants() { Id = 19, Price = 10.20M, ProductId = 19, ConditionId = 1, EditionId = 2 },
				new ProductVariants() { Id = 20, Price = 10.20M, ProductId = 20, ConditionId = 1, EditionId = 3 },
				new ProductVariants() { Id = 21, Price = 10.20M, ProductId = 21, ConditionId = 2, EditionId = 1 },
				new ProductVariants() { Id = 22, Price = 10.20M, ProductId = 22, ConditionId = 2, EditionId = 3 },
				new ProductVariants() { Id = 23, Price = 10.20M, ProductId = 23, ConditionId = 3, EditionId = 1 },
				new ProductVariants() { Id = 24, Price = 10.20M, ProductId = 24, ConditionId = 3, EditionId = 2 },
				new ProductVariants() { Id = 25, Price = 10.20M, ProductId = 25, ConditionId = 3, EditionId = 2 },
				new ProductVariants() { Id = 26, Price = 10.20M, ProductId = 26, ConditionId = 3, EditionId = 1 },
				new ProductVariants() { Id = 27, Price = 10.20M, ProductId = 27, ConditionId = 2, EditionId = 3 },
				new ProductVariants() { Id = 28, Price = 10.20M, ProductId = 28, ConditionId = 2, EditionId = 1 },
				new ProductVariants() { Id = 29, Price = 10.20M, ProductId = 29, ConditionId = 1, EditionId = 3 },
				new ProductVariants() { Id = 30, Price = 10.20M, ProductId = 30, ConditionId = 1, EditionId = 2 },
			};

			return productVariantsInit;
		}
	}
}

