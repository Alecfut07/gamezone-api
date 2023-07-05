using gamezone_api.Helpers;
using gamezone_api.Networking;
using gamezone_api.Parameters;

namespace gamezone_api.Services
{

    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetProducts();

        Task<ProductResponse?> GetProductById(long id);

        Task<PagedList<ProductResponse>> GetProductsByPaging(ProductParameters productParameters);

        Task<List<ProductResponse>> GetProductsByCollection();

        Task<PagedList<ProductResponse>> SearchProducts(SearchParameter searchParameter);

        Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest);

        ImageResponse? UploadImage(ImageRequest imageRequest);

        Task<ProductResponse?> UpdateProduct(long id, ProductRequest product);

        Task DeleteProduct(long id);
    }
}
