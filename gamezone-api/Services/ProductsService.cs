using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
    public class ProductsService : BaseService, IProductService
    {
        private IProductsRepository _productsRepository;
        private IProductsMapper _productsMapper;

        public ProductsService(ILogger logger, IProductsRepository productsRepository, IProductsMapper productsMapper)
            : base(logger)
        {
            _productsRepository = productsRepository;
            _productsMapper = productsMapper;
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            try
            {
                var products = await _productsRepository.GetProducts();
                return products.ConvertAll<ProductResponse>(p => _productsMapper.Map(p));
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<ProductResponse?> GetProductById(long id)
        {
            try
            {
                var product = await _productsRepository.GetProductById(id);
                if (product != null)
                {
                    var productResponse = _productsMapper.Map(product);
                    return productResponse;
                }
                return null;
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PagedList<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            try
            {
                if (productParameters.PageNumber != null && productParameters.PageSize != null)
                {
                    var products = await _productsRepository.GetProductsByPaging(productParameters);
                    var productsResponses = products.ConvertAll<ProductResponse>(p => _productsMapper.Map(p));
                    var pageNumber = productParameters.PageNumber ?? 0;
                    var pageSize = productParameters.PageSize ?? 0;

                    var productsByPaging = PagedList<ProductResponse>
                        .ToPagedList(
                            productsResponses.OrderBy((prods) => prods.Name),
                            0,
                            pageNumber,
                            pageSize
                            );

                    return productsByPaging;
                }
                return new PagedList<ProductResponse>();
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<List<ProductResponse>> GetProductsByCollection()
        {
            try
            {
                var products = await _productsRepository.GetProductsByCollection();
                return products.ConvertAll<ProductResponse>(p => _productsMapper.Map(p));
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PagedList<ProductResponse>> SearchProducts(SearchParameter searchParameter)
        {
            try
            {
                if (searchParameter.Name != null && searchParameter.PageNumber != null && searchParameter.PageSize != null)
                {
                    var (count, products) = await _productsRepository.SearchProducts(searchParameter);
                    var productsResponse = products.ConvertAll<ProductResponse>(p => _productsMapper.Map(p));
                    var pageNumber = searchParameter.PageNumber ?? 0;
                    var pageSize = searchParameter.PageSize ?? 0;

                    var productsByPaging = PagedList<ProductResponse>
                        .ToPagedList(
                            productsResponse.OrderBy((prods) => prods.Name),
                            count,
                            pageNumber,
                            pageSize
                            );

                    return productsByPaging;
                }
                return new PagedList<ProductResponse>();
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest)
        {
            try
            {
                var newProduct = _productsMapper.Map(productRequest);
                var product = await _productsRepository.SaveNewProduct(newProduct);
                var productResponse = _productsMapper.Map(product);
                return productResponse;
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public ImageResponse? UploadImage(ImageRequest imageRequest)
        {
            try
            {
                var file = imageRequest.Image;
                if (file == null)
                {
                    throw new ArgumentNullException();
                }
                else
                {
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (!Directory.Exists(pathToSave))
                    {
                        // Create the directory
                        DirectoryInfo di = Directory.CreateDirectory(pathToSave);
                    }

                    if (file.Length > 0)
                    {
                        var uniqueFileName = Convert.ToString(Guid.NewGuid() + Path.GetExtension(file.FileName));
                        var fullPathToSave = Path.Combine(pathToSave, uniqueFileName);
                        using (var stream = new FileStream(fullPathToSave, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        var imageKey = Path.Combine("Images", uniqueFileName);
                        ImageResponse response = new ImageResponse()
                        {
                            ImageKey = imageKey
                        };
                        return response;
                    }
                    return null;
                }
            }
            catch (IOException ex)
            {
                _logger.LogError(ex, "The process failed");
                throw;
            }
        }

        public async Task<ProductResponse?> UpdateProduct(long id, ProductRequest productRequest)
        {
            try
            {
                var productToUpdate = _productsMapper.Map(productRequest);
                var product = await _productsRepository.UpdateProduct(id, productToUpdate);
                if (product == null)
                {
                    throw new KeyNotFoundException();
                }
                return _productsMapper.Map(product);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task DeleteProduct(long id)
        {
            try
            {
                await _productsRepository.DeleteProduct(id);
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }
    }
}

