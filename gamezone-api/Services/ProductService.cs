using System;
using gamezone_api.Models;
namespace gamezone_api.Services
{
    public class ProductService : IProductService
    {
        GamezoneContext context;
        public ProductService(GamezoneContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Product> Get()
        {
            return context.Products;
        }


        public async Task Save(Product product)
        {
            context.Add(product);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public async Task Update(Guid id, Product product)
        {
            var actualProduct = context.Products.Find(id);

            if (actualProduct != null)
            {
                actualProduct.Name = product.Name;
                actualProduct.Description = product.Description;
                actualProduct.Price = product.Price;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var actualProduct = context.Products.Find(id);

            if (actualProduct != null)
            {
                context.Remove(actualProduct);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IProductService
    {
        IEnumerable<Product> Get();

        Task Save(Product product);

        Task Update(Guid id, Product product);

        Task Delete(Guid id);
    }
}

