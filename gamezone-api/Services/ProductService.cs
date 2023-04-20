using System;
using System.Net;
using System.Runtime.Serialization;
using gamezone_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
    public class ProductService : IProductService
    {
        GamezoneContext context;

        public ProductService(GamezoneContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .SingleOrDefaultAsync(p => p.Id == id);
            return product;
        }

        public async Task<Product?> SaveNewProduct(Product newProduct)
        {
            newProduct.CreateDate = DateTime.UtcNow;
            newProduct.UpdateDate = DateTime.UtcNow;

            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            return newProduct;
        }

        public async Task<Product?> UpdateProduct(long id, Product product)
        {
            var result = await context.Products
                .Where((p) => p.Id == id)
                .ExecuteUpdateAsync((prod) =>
                    prod
                        .SetProperty((p) => p.Name, product.Name)
                        .SetProperty((p) => p.Price, product.Price)
                        .SetProperty((p) => p.ReleaseDate, product.ReleaseDate)
                        .SetProperty((p) => p.Description, product.Description)
                        .SetProperty((p) => p.ConditionId, product.ConditionId)
                        .SetProperty((p) => p.EditionId, product.EditionId)
                        );
            if (result > 0)
            {
                var updatedProduct = await context.Products
                    .Include(p => p.Condition)
                    .Include(p => p.Edition)
                    .SingleAsync(p => p.Id == id);
                return updatedProduct;
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteProduct(long id)
        {
            var productToRemove = await context.Products.FindAsync(id);

            if (productToRemove == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                context.Products.Remove(productToRemove);
                await context.SaveChangesAsync();
            }
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

