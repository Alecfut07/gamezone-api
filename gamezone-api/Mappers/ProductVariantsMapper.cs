using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ProductVariantsMapper
	{
		private ProductsMapper _productsMapper;
		private ConditionsMapper _conditionsMapper;
		private EditionsMapper _editionsMapper;

		public ProductVariantsMapper(ProductsMapper productsMapper, ConditionsMapper conditionsMapper, EditionsMapper editionsMapper)
		{
			_productsMapper = productsMapper;
			_conditionsMapper = conditionsMapper;
			_editionsMapper = editionsMapper;
		}

		public ProductVariants Map(ProductVariantRequest productVariantRequest)
		{
			return new ProductVariants
			{
				Price = productVariantRequest.Price,
				ProductId = productVariantRequest.ProductId,
				ConditionId = productVariantRequest.ConditionId,
				EditionId = productVariantRequest.EditionId,
			};
		}

		public ProductVariantResponse Map(ProductVariants productVariants)
		{
			return new ProductVariantResponse
			{
				Id = productVariants.Id,
				Price = productVariants.Price,
				Product = _productsMapper.Map(productVariants.Product),
				Condition = _conditionsMapper.Map(productVariants.Condition),
				Edition = _editionsMapper.Map(productVariants.Edition),
			};
		}
	}
}

