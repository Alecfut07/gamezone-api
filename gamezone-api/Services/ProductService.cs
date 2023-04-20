using System;
using System.Net;
using System.Runtime.Serialization;
using gamezone_api.Models;
using gamezone_api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
    public class ProductService : IProductService
    {
        GamezoneContext context;

        private ProductsRepository productsRepository;

        public ProductService(GamezoneContext dbContext, ProductsRepository productsRepository)
        {
            context = dbContext;
            this.productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await productsRepository.GetProducts();
            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await productsRepository.GetProductById(id);
            return product;
        }

        public async Task<Product?> SaveNewProduct(Product newProduct)
        {
            var createdNewProduct = await productsRepository.SaveNewProduct(newProduct);

            return createdNewProduct;
        }

        public async Task<Product?> UpdateProduct(long id, Product product)
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
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProductById(long id);

        Task<Product?> SaveNewProduct(Product newProduct);

        Task<Product?> UpdateProduct(long id, Product product);

        Task DeleteProduct(long id);
    }
}

