using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ProductsMapper: IProductsMapper
    {
        private IConditionsMapper _conditionsMapper;
        private IEditionsMapper _editionsMapper;
        private IHttpContextAccessor _httpContextAccessor;

        public ProductsMapper(IConditionsMapper conditionsMapper, IEditionsMapper editionsMapper, IHttpContextAccessor httpContextAccessor)
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
                CategoriesProductVariants = Map(productVariantRequest.CategoriesRequests.ToList(), productVariantRequest.Id)
                //CategoryId = productVariantRequest.CategoryProductVariantId
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
                CategoriesResponses = Map(productVariant.CategoriesProductVariants.ToList())
            };
        }

        public List<ProductVariantResponse> Map(List<ProductVariant> productVariants)
        {
            return productVariants.ConvertAll<ProductVariantResponse>((pv) => Map(pv));
        }

        public CategoryProductVariant Map(CategoryProductVariantRequest categoryProductVariantRequest, long productVariantId)
        {
            return new CategoryProductVariant
            {
                CategoryId = categoryProductVariantRequest.CategoryProductVariantId,
                ProductVariantId = productVariantId
            };
        }

        public List<CategoryProductVariant> Map(List<CategoryProductVariantRequest> categoryProductVariantRequests, long id)
        {
            return categoryProductVariantRequests.ConvertAll<CategoryProductVariant>((cpvr) => Map(cpvr, id));
        }

        public CategoryProductVariantResponse Map(CategoryProductVariant category)
        {
            return new CategoryProductVariantResponse
            {
                Id = category.CategoryId,
                Name = category.Category.Name
            };
        }

        public List<CategoryProductVariantResponse> Map(List<CategoryProductVariant> categories)
        {
            return categories.ConvertAll<CategoryProductVariantResponse>((c) => Map(c));
        }
    }

    public interface IProductsMapper
    {
        public Product Map(ProductRequest productRequest, long id = 0);

        public ProductResponse Map(Product product);

        public ProductVariant Map(ProductVariantRequest productVariantRequest);

        public List<ProductVariant> Map(List<ProductVariantRequest> productVariantRequests);

        public ProductVariantResponse Map(ProductVariant productVariant);

        public List<ProductVariantResponse> Map(List<ProductVariant> productVariants);

        public CategoryProductVariant Map(CategoryProductVariantRequest categoryProductVariantRequest, long productVariantId);

        public List<CategoryProductVariant> Map(List<CategoryProductVariantRequest> categoryProductVariantRequests, long id);

        public CategoryProductVariantResponse Map(CategoryProductVariant category);

        public List<CategoryProductVariantResponse> Map(List<CategoryProductVariant> categories);
    }
}

