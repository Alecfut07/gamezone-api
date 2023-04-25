using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using Microsoft.EntityFrameworkCore;

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

		public async Task<IEnumerable<ProductResponse>> GetProducts()
		{
            var products = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .ToListAsync();

            var productsResponse = products.ConvertAll<ProductResponse>((p) => productsMapper.Map(p));
            return productsResponse;
        }

        public async Task<ProductResponse?> GetProductById(long id)
        {
            var product = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .SingleOrDefaultAsync(p => p.Id == id);

            var productResponse = productsMapper.Map(product);
            return productResponse;
        }

        public async Task<IEnumerable<ProductResponse>> GetProductsByPaging(ProductParameters productParameters)
        {
            var products = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .ToListAsync();

            var productsResponse = products.ConvertAll<ProductResponse>((p) => productsMapper.Map(p));

            if (productParameters.PageNumber != null && productParameters.PageSize != null)
            {
                var pageNumber = productParameters.PageNumber ?? 0;
                var pageSize = productParameters.PageSize ?? 0;

                var productsByPaging = productsResponse
                    .OrderBy((prods) => prods.Name)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return productsByPaging;
            }
            else
            {
                return productsResponse;
            }
        }

        public async Task<ProductResponse?> SaveNewProduct(ProductRequest productRequest)
        {
            var newProduct = productsMapper.Map(productRequest);
            newProduct.CreateDate = DateTime.UtcNow;
            newProduct.UpdateDate = DateTime.UtcNow;

            context.Products.Add(newProduct);
            await context.SaveChangesAsync();

            var product = await context.Products
                .Include(p => p.Condition)
                .Include(p => p.Edition)
                .SingleOrDefaultAsync(p => p.Id == newProduct.Id);

            var productResponse = productsMapper.Map(product);

            return productResponse;
        }

        public async Task<ProductResponse?> UpdateProduct(long id, ProductRequest productRequest)
        {
            var result = await context.Products
                .Where((p) => p.Id == id)
                .ExecuteUpdateAsync((prod) =>
                    prod
                        .SetProperty((p) => p.Name, productRequest.Name)
                        .SetProperty((p) => p.Price, productRequest.Price)
                        .SetProperty((p) => p.ReleaseDate, productRequest.ReleaseDate)
                        .SetProperty((p) => p.Description, productRequest.Description)
                        .SetProperty((p) => p.ConditionId, productRequest.ConditionId)
                        .SetProperty((p) => p.EditionId, productRequest.EditionId)
                        .SetProperty((p) => p.UpdateDate, DateTime.UtcNow)
                        );
            if (result > 0)
            {
                var updatedProduct = await context.Products
                    .Include(p => p.Condition)
                    .Include(p => p.Edition)
                    .SingleAsync(p => p.Id == id);

                var productResponse = productsMapper.Map(updatedProduct);
                return productResponse;
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
}

