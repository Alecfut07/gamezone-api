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
            var products = await context.Products.ToListAsync();
            return products;
        }

        public async Task<Product?> GetProduct(long id)
        {
            var product = await context.Products.FindAsync(id);
            return product;
        }

        public async Task<Product?> Save(Product product)
        {
            product.CreateDate = DateTime.UtcNow;
            product.UpdateDate = DateTime.UtcNow;

            context.Products.Add(product);
            await context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> Update(long id, Product product)
        {
            var updatedProduct = await context.Products.FindAsync(id);

            if (updatedProduct != null)
            {
                updatedProduct.Name = product.Name;
                updatedProduct.Price = product.Price;
                updatedProduct.ReleaseDate = product.ReleaseDate;
                updatedProduct.Description = product.Description;

                //var isNameModified = context.Entry(actualProduct).Property("name").IsModified;
                //var isPriceModified = context.Entry(actualProduct).Property("price").IsModified;
                //var isReleaseModified = context.Entry(actualProduct).Property("release_date").IsModified;
                //var isDescriptionModified = context.Entry(actualProduct).Property("description").IsModified;

                
                //context.Products.Update(actualProduct);
                await context.SaveChangesAsync();
            }

            return updatedProduct;
        }

        public async Task Delete(long id)
        {
            var productToRemove = await context.Products.FindAsync(id);

            if (productToRemove == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                context.Remove(productToRemove);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();

        Task<Product?> GetProduct(long id);

        Task<Product?> Save(Product product);

        Task<Product?> Update(long id, Product product);

        Task Delete(long id);
    }
}

