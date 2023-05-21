using System;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace gamezone_api.Repositories
{
	public class ProductsRepository
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
                .ToListAsync();

            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<List<Product>> GetProductsByPaging(ProductParameters productParameters)
        {
            var products = await _context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .ToListAsync();

            if (productParameters.PageNumber != null && productParameters.PageSize != null)
            {
                var pageNumber = productParameters.PageNumber ?? 0;
                var pageSize = productParameters.PageSize ?? 0;

                var productsByPaging = PagedList<Product>
                    .ToPagedList(
                        products.OrderBy((prods) => prods.Name),
                        pageNumber,
                        pageSize
                        );

                return productsByPaging;
            }
            else
            {
                return new List<Product>();
            }
        }

        public async Task<List<Product>> SearchProducts(SearchParameter searchParameter)
        {
            var query = searchParameter.Query ?? "";
            var products = await _context.Products
                .Where((prod) => prod.Name.ToLower().Contains(query.ToLower()))
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .ToListAsync();

            return products;
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
                .SingleAsync(p => p.Id == product.Id);

            return newProduct;
        }

        public async Task<Product?> UpdateProduct(long id, Product product)
        {
            var productToUpdate = await _context.Products
                    .Include(p => p.ProductVariants)
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

                await _context.SaveChangesAsync();

                var updatedProduct = await _context.Products
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                   .SingleAsync(p => p.Id == productToUpdate.Id);

                return updatedProduct;
            }
            return null;
        }

        public async Task DeleteProduct(long id)
        {
            var productToRemove = await _context.Products.FindAsync(id);
            if (productToRemove != null)
            {
                _context.Products.Remove(productToRemove);
                await _context.SaveChangesAsync();
            }
        }
	}
}

