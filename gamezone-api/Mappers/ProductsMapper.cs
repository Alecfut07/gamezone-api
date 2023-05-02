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
        public Product Map(ProductRequest productRequest)
        {
            return new Product
            {
                ImageURL = productRequest.ImageURL,
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                ReleaseDate = productRequest.ReleaseDate == null ? null : productRequest.ReleaseDate.Value.ToUniversalTime(),
                ConditionId = productRequest.ConditionId,
                EditionId = productRequest.EditionId,
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
                Price = product.Price,
                ReleaseDate = product.ReleaseDate,
                Condition = _conditionsMapper.Map(product.Condition),
                Edition = _editionsMapper.Map(product.Edition),
                CreateDate = product.CreateDate,
                UpdateDate = product.UpdateDate
            };
        }
    }
}

