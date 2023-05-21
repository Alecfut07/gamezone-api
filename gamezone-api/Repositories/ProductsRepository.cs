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
        private GamezoneContext context;
        private ProductsMapper productsMapper;

        public ProductsRepository(GamezoneContext dbContext, ProductsMapper productsMapper)
		{
			context = dbContext;
            this.productsMapper = productsMapper;
		}

        public async Task<List<Product>> GetProducts()
        {
            var products = await context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .ToListAsync();

            return products;
        }

        public async Task<Product?> GetProductById(long id)
        {
            var product = await context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .SingleOrDefaultAsync(p => p.Id == id);

            return product;
        }

        public async Task<List<Product>> GetProductsByPaging(ProductParameters productParameters)
        {
            var products = await context.Products
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
            var products = await context.Products
                .Where((prod) => prod.Name.ToLower().Contains(query.ToLower()))
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .ToListAsync();

            return products;
        }

        public async Task<Product> SaveNewProduct(ProductRequest productRequest)
        {
            var newProduct = productsMapper.Map(productRequest);
            newProduct.CreateDate = DateTime.UtcNow;
            newProduct.UpdateDate = DateTime.UtcNow;

            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            var product = await context.Products
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                .SingleAsync(p => p.Id == newProduct.Id);

            return product;
        }

        public async Task<Product?> UpdateProduct(long id, ProductRequest productRequest)
        {
            var product = await context.Products
                    .Include(p => p.ProductVariants)
                    .SingleOrDefaultAsync(p => p.Id == id);

            if (product != null)
            {
                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.ImageKey = productRequest.ImageKey;
                product.ReleaseDate = productRequest.ReleaseDate;
                product.UpdateDate = DateTime.UtcNow;

                var incomingProductVariants = productsMapper.Map(productRequest.ProductVariantRequests.ToList());
                product.ProductVariants
                    .Where((pv) => !incomingProductVariants.Contains(pv))
                    .ToList()
                    .ForEach((pv) => context.Entry(pv).State = EntityState.Deleted);

                product.ProductVariants = incomingProductVariants;

                await context.SaveChangesAsync();

                var updatedProduct = await context.Products
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Edition)
                   .Include(p => p.ProductVariants).ThenInclude(pv => pv.Condition)
                   .SingleAsync(p => p.Id == product.Id);

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
                throw new KeyNotFoundException();
            }
            else
            {
                context.Products.Remove(productToRemove);
                await context.SaveChangesAsync();
            }
        }
	}
}

