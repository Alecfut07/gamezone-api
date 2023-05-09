using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using gamezone_api.Helpers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
    public class ProductService : IProductService
    {
        private ProductsRepository productsRepository;

        public ProductService(ProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<ProductResponse>> GetProducts()
        {
            var products = await productsRepository.GetProducts();
            return products;
        }

        public async Task<ProductResponse?> GetProductById(long id)
        {
            var product = await productsRepository.GetProductById(id);
            return product;
        }

        public async Task<List<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            var productsByPaging = await productsRepository.GetProductsByPaging(productParameters);
            return productsByPaging;

        }

        public async Task<List<ProductResponse>> SearchProducts(SearchParameter searchParameter)
        {
            var searchedProducts = await productsRepository.SearchProducts(searchParameter);
            return searchedProducts;
        }

        public async Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest)
        {
            var productResponse = await productsRepository.SaveNewProduct(productRequest);
            return productResponse;
        }

        public async Task<ImageResponse?> UploadImage(ImageRequest imageRequest)
        {
            var file = imageRequest.Image;
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

        public async Task<ProductResponse?> UpdateProduct(long id, ProductRequest product)
        {
            return await productsRepository.UpdateProduct(id, product);
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

