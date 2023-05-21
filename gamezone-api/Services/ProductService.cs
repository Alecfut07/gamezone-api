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
    public class ProductService : IProductService
    {
        private ProductsRepository productsRepository;
        private ProductsMapper productsMapper;

        public ProductService(ProductsRepository productsRepository, ProductsMapper productsMapper)
        {
            this.productsRepository = productsRepository;
            this.productsMapper = productsMapper;
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            var products = await productsRepository.GetProducts();
            return products.ConvertAll<ProductResponse>((p) => productsMapper.Map(p));
        }

        public async Task<ProductResponse?> GetProductById(long id)
        {
            var product = await productsRepository.GetProductById(id);
            if (product != null)
            {
                var productResponse = productsMapper.Map(product);
                return productResponse;
            }
            return null;
        }

        public async Task<List<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            var products = await productsRepository.GetProductsByPaging(productParameters);
            var productsResponse = products.ConvertAll<ProductResponse>((p) => productsMapper.Map(p));
            return productsResponse;

        }

        public async Task<List<ProductResponse>> SearchProducts(SearchParameter searchParameter)
        {
            var products = await productsRepository.SearchProducts(searchParameter);
            var productsResponse = products.ConvertAll<ProductResponse>((p) => productsMapper.Map(p));
            //productsResponse.Any() ? productsResponse : null;
            return productsResponse;
        }

        public async Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest)
        {
            var product = await productsRepository.SaveNewProduct(productRequest);
            var productResponse = productsMapper.Map(product);
            return productResponse;
        }

        public async Task<ImageResponse?> UploadImage(ImageRequest imageRequest)
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

                try
                {
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

                }
                catch (Exception ex)
                {
                    Console.WriteLine("The process failed: {0}", ex.ToString());
                }

                return null;
            }
        }

        public async Task<ProductResponse?> UpdateProduct(long id, ProductRequest productRequest)
        {
            var product = await productsRepository.UpdateProduct(id, productRequest);

            if (product != null)
            {
                return productsMapper.Map(product);
            }
            return null;
        }

        public async Task DeleteProduct(long id)
        {
            await productsRepository.DeleteProduct(id);
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetProducts();

        Task<ProductResponse?> GetProductById(long id);

        Task<List<ProductResponse>> GetProductsByPaging(ProductParameters productParameters);

        Task<List<ProductResponse>> SearchProducts(SearchParameter searchParameter);

        Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest);

        Task<ImageResponse?> UploadImage(ImageRequest imageRequest);

        Task<ProductResponse?> UpdateProduct(long id, ProductRequest product);

        Task DeleteProduct(long id);
    }
}

