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
                .Include("Condition")
                .ToListAsync();
            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await context.Products
                .Include("Condition")
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
            var productToUpdate = await context.Products.FindAsync(id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.ReleaseDate = product.ReleaseDate;
                productToUpdate.Description = product.Description;

                //var isNameModified = context.Entry(actualProduct).Property("name").IsModified;
                //var isPriceModified = context.Entry(actualProduct).Property("price").IsModified;
                //var isReleaseModified = context.Entry(actualProduct).Property("release_date").IsModified;
                //var isDescriptionModified = context.Entry(actualProduct).Property("description").IsModified;

                
                //context.Products.Update(actualProduct);
                await context.SaveChangesAsync();
            }

            return productToUpdate;
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

