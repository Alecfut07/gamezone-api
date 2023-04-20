using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ProductsMapper
    {
        public Product Map(ProductRequest productRequest)
        {
            return new Product
            {
                Name = productRequest.Name,
                Description = productRequest.Description,
                Price = productRequest.Price,
                ReleaseDate = productRequest.ReleaseDate,
                ConditionId = productRequest.ConditionId,
                EditionId = productRequest.EditionId,
            };
        }

        public ProductResponse Map(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ReleaseDate = product.ReleaseDate,
                Condition = product.Condition,
                Edition = product.Edition,
                CreateDate = product.CreateDate,
                UpdateDate = product.UpdateDate
            };
        }
    }
}

