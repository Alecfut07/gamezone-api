using System;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
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

        public async Task<IEnumerable<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            var productsByPaging = await productsRepository.GetProductsByPaging(productParameters);
            return productsByPaging;

        }

        public async Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest)
        {
            var productResponse = await productsRepository.SaveNewProduct(productRequest);
            return productResponse;
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

        Task<IEnumerable<ProductResponse>> GetProductsByPaging(ProductParameters productParameters); 

        Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest);

        Task<ProductResponse?> UpdateProduct(long id, ProductRequest product);

        Task DeleteProduct(long id);
    }
}

