using System;
using System.Drawing.Printing;
using System.Linq.Expressions;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace gamezone_api.Repositories
{
	public class ProductsRepository: IProductsRepository
	{
        private GamezoneContext _context;

        public ProductsRepository(GamezoneContext context)
		{
			_context = context;
		}

        public async Task<List<Product>> GetProducts()
        {
            var products = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                .ToListAsync();

            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<List<Product>> GetProductsByPaging(ProductParameters productParameters)
        {
            var pageNumber = productParameters.PageNumber ?? 0;
            var pageSize = productParameters.PageSize ?? 0;

            var products = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return products;
        }

        public async Task<List<Product>> GetProductsByCollection()
        {
            var randomProductIds = await _context.Products
                .Select(p => p.Id)
                .ToListAsync();

            var productIds = randomProductIds.Shuffle().Take(12);

            var products = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            return products;
        }

        public async Task<(int, List<Product>)> SearchProducts(SearchParameter searchParameter)
        {
            var name = searchParameter.Name ?? null;
            var category = searchParameter.Category ?? null;
            var pageNumber = searchParameter.PageNumber ?? 0;
            var pageSize = searchParameter.PageSize ?? 0;

            var productVariantsOfTheCategory = await _context.Categories
                .Where(c => c.Handle == category)
                //.Include(c => c.CategoriesProductVariants)
                //.Include(c => c.CategoriesProductVariants).ThenInclude(x => x.Category)
                .SelectMany(c => c.CategoriesProductVariants.Select(cpv => cpv.ProductVariantId))
                //.SelectMany(c => c.CategoriesProductVariants.Select(cpv => cpv.ProductVariant))
                .ToListAsync();

            // [1, 2, 3].map (n => n * 100)  // [100, 200, 300]
            // [1, 2, 3].map (n => new List<int>() { n }) // List { List { 1 }, List { 2 }, List { 3 } }
            // [1, 2, 3].flatMap (n => new List<int>() { n }) // List { 1, 2, 3} }

            Expression<Func<Product, bool>> predicate = null;
            if (name != null && category != null)
            {
                predicate = (p => p.Name.ToLower().Contains(name.ToLower()) && p.ProductVariants.Any(pv => productVariantsOfTheCategory.Contains(pv.Id)));
            }
            else if (name != null && category == null)
            {
                predicate = p => p.Name.ToLower().Contains(name.ToLower());
            }
            else if (name == null && category != null)
            {
                predicate = p => p.ProductVariants.Any(pv => productVariantsOfTheCategory.Contains(pv.Id));
            }
            var products = await GetProductsByPredicate(predicate, pageNumber, pageSize);
            var count = await GetProductsCount(predicate);
            return (count, products);
        }

        public async Task<Product> SaveNewProduct(Product product)
        {
            product.CreateDate = DateTime.UtcNow;
            product.UpdateDate = DateTime.UtcNow;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            var newProduct = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                .SingleAsync(p => p.Id == product.Id);

            return newProduct;
        }

        public async Task<Product?> UpdateProduct(long id, Product product)
        {
            var productToUpdate = await _context.Products
                    .Include(p => p.ProductVariants)
                    .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                    .SingleOrDefaultAsync(p => p.Id == id);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Description = product.Description;
                productToUpdate.ImageKey = product.ImageKey;
                productToUpdate.ReleaseDate = product.ReleaseDate;
                productToUpdate.UpdateDate = DateTime.UtcNow;

                var incomingProductVariants = product.ProductVariants;
                productToUpdate.ProductVariants
                    .Where((pv) => !incomingProductVariants.Contains(pv))
                    .ToList()
                    .ForEach((pv) => _context.Entry(pv).State = EntityState.Deleted);

                productToUpdate.ProductVariants = incomingProductVariants;

                _context.Entry(productToUpdate).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                var updatedProduct = await _context.Products
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(cpv => cpv.Category)
                   .SingleAsync(p => p.Id == productToUpdate.Id);

                return updatedProduct;
            }
            return null;
        }

        public async Task DeleteProduct(long id)
        {
            var productToRemove = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(x => x.Category)
                .FirstAsync(p => p.Id == id);
                //.FindAsync(id);
            if (productToRemove != null)
            {
                _context.Products.Remove(productToRemove);
                await _context.SaveChangesAsync();
            }
        }

        private async Task<List<Product>> GetProductsByPredicate(Expression<Func<Product, bool>> predicate, int pageNumber, int pageSize)
        {
            var products = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(x => x.Category)
                .Where(predicate)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .ToListAsync();

            return products;
        }

        private async Task<int> GetProductsCount(Expression<Func<Product, bool>> predicate)
        {
            var count = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.CategoriesProductVariants).ThenInclude(x => x.Category)
                .Where(predicate)
                .CountAsync();

            return count;
        }
    }

    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(long id);
        Task<List<Product>> GetProductsByPaging(ProductParameters productParameters);
        Task<List<Product>> GetProductsByCollection();
        Task<(int, List<Product>)> SearchProducts(SearchParameter searchParameter);
        Task<Product> SaveNewProduct(Product product);
        Task<Product?> UpdateProduct(long id, Product product);
        Task DeleteProduct(long id);
    }
}
