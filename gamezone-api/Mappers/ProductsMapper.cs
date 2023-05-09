using System;
using System.Web;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ProductsMapper
    {
        private ConditionsMapper _conditionsMapper;
        private EditionsMapper _editionsMapper;
        private IHttpContextAccessor _httpContextAccessor;

        public ProductsMapper(ConditionsMapper conditionsMapper, EditionsMapper editionsMapper, IHttpContextAccessor httpContextAccessor)
        {
            _conditionsMapper = conditionsMapper;
            _editionsMapper = editionsMapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public Product Map(ProductRequest productRequest, long id = 0)
        {
            return new Product
            {
                Id = id,
                ImageURL = productRequest.ImageURL,
                ImageKey = productRequest.ImageKey,
                Name = productRequest.Name,
                Description = productRequest.Description,
                ReleaseDate = productRequest.ReleaseDate == null ? null : productRequest.ReleaseDate.Value.ToUniversalTime(),
                ProductVariants = Map(productRequest.ProductVariantRequests.ToList())
            };
        }

        private string? GetImageUrl(Product product)
        {
            if (product.ImageKey == null)
            {
                return product.ImageURL;
            }
            else
            {
                //var httpProtocol = "https";
                //var domain = "localhost";
                //var portNumber = "7269";

                string protocol = _httpContextAccessor.HttpContext.Request.Scheme;
                string domain = _httpContextAccessor.HttpContext.Request.Host.Host;
                int? portNumber = _httpContextAccessor.HttpContext.Request.Host.Port;

                var url = $"{protocol}://{domain}:{portNumber}/public/{product.ImageKey}";
                return url;
            }
        }

        public ProductResponse Map(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                ImageURL = GetImageUrl(product),
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

