using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace gamezone_api.Services
{
    public class ProductsService : BaseService, IProductService
    {
        private IProductsRepository _productsRepository;
        private ProductsMapper _productsMapper;

        public ProductsService(ILogger logger, IProductsRepository productsRepository, ProductsMapper productsMapper)
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
                return products.ConvertAll<ProductResponse>((p) => _productsMapper.Map(p));
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PagedList<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            try
            {
                var products = await _productsRepository.GetProductsByPaging(productParameters);
                var productsResponse = products.ConvertAll<ProductResponse>((p) => _productsMapper.Map(p));
                if (productParameters.PageNumber != null && productParameters.PageSize != null)
                {
                    var pageNumber = productParameters.PageNumber ?? 0;
                    var pageSize = productParameters.PageSize ?? 0;

                    var productsByPaging = PagedList<ProductResponse>
                        .ToPagedList(
                            productsResponse.OrderBy((prods) => prods.Name),
                            0,
                            pageNumber,
                            pageSize
                            );

                    return productsByPaging;
                }
                else
                {
                    return new PagedList<ProductResponse>();
                }
            }
            catch (Exception ex)
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
                return products.ConvertAll<ProductResponse>((p) => _productsMapper.Map(p));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PagedList<ProductResponse>> SearchProducts(SearchParameter searchParameter)
        {
            try
            {
                var (count, products) = await _productsRepository.SearchProducts(searchParameter);
                var productsResponse = products.ConvertAll<ProductResponse>((p) => _productsMapper.Map(p));
                if (searchParameter.PageNumber != null && searchParameter.PageSize != null)
                {
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
                else
                {
                    return new PagedList<ProductResponse>();
                }
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }
    }

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

