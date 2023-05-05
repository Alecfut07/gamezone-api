using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ProductsMapper
    {
        private ConditionsMapper _conditionsMapper;
        private EditionsMapper _editionsMapper;

        public ProductsMapper(ConditionsMapper conditionsMapper, EditionsMapper editionsMapper)
        {
            _conditionsMapper = conditionsMapper;
            _editionsMapper = editionsMapper;
        }

        public Product Map(ProductRequest productRequest, long id = 0)
        {
            return new Product
            {
                Id = id,
                ImageURL = productRequest.ImageURL,
                Name = productRequest.Name,
                Description = productRequest.Description,
                ReleaseDate = productRequest.ReleaseDate == null ? null : productRequest.ReleaseDate.Value.ToUniversalTime(),
                ProductVariants = Map(productRequest.ProductVariantRequests.ToList())
            };
        }

        public ProductResponse Map(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                ImageURL = product.ImageURL,
                Name = product.Name,
                Description = product.Description,
                ReleaseDate = product.ReleaseDate,
                CreateDate = product.CreateDate,
                UpdateDate = product.UpdateDate,
                ProductVariantResponses = Map(product.ProductVariants.ToList())
            };
        }

        public ProductVariant Map(ProductVariantRequest productVariantRequest)
        {
            return new ProductVariant
            {
                Id = productVariantRequest.Id,
                Price = productVariantRequest.Price,
                ConditionId = productVariantRequest.ConditionId,
                EditionId = productVariantRequest.EditionId,
            };
        }

        public List<ProductVariant> Map(List<ProductVariantRequest> productVariantRequests)
        {
            return productVariantRequests.ConvertAll<ProductVariant>((pvr) => Map(pvr));
        }

        public ProductVariantResponse Map(ProductVariant productVariant)
        {
            return new ProductVariantResponse
            {
                Id = productVariant.Id,
                Price = productVariant.Price,
                Condition = _conditionsMapper.Map(productVariant.Condition),
                Edition = _editionsMapper.Map(productVariant.Edition),
            };
        }

        public List<ProductVariantResponse> Map(List<ProductVariant> productVariants)
        {
            return productVariants.ConvertAll<ProductVariantResponse>((pv) => Map(pv));
        }
    }
}

