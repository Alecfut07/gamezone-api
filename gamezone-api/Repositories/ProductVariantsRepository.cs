using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	//public class ProductVariantsRepository
	//{
	//	private GamezoneContext context;

	//	public ProductVariantsRepository(GamezoneContext dbContext)
	//	{
	//		context = dbContext;
	//	}

	//	public async Task<IEnumerable<ProductVariantResponse>> GetProductVariants()
	//	{
	//		var productVariants = await context.ProductVariants
	//			.Include(pv => pv.Product)
	//			.Include(pv => pv.Condition)
	//			.Include(pv => pv.Edition)
	//			.ToListAsync();

	//		var productVariantsResponse = productVariants.ConvertAll<ProductVariantResponse>((pv) => productVariantsMapper.Map(pv));
	//		return productVariantsResponse;
	//	}

	//	public async Task<ProductVariantResponse?> GetProductVariantById(long id)
	//	{
	//		var productVariant = await context.ProductVariants
	//			.Include(pv => pv.Product)
	//			.Include(pv => pv.Condition)
	//			.Include(pv => pv.Edition)
	//			.SingleOrDefaultAsync(pv => pv.Id == id);

	//		var productVariantResponse = productVariantsMapper.Map(productVariant);
	//		return productVariantResponse;
	//	}

	//	public async Task<ProductVariantResponse?> SaveNewProductVariant(ProductVariantRequest productVariantRequest)
	//	{
	//		var newProductVariant = productVariantsMapper.Map(productVariantRequest);

	//		context.ProductVariants.Add(newProductVariant);
	//		await context.SaveChangesAsync();

	//		var productVariant = await context.ProductVariants
	//			.Include(pv => pv.Product)
	//			.Include(pv => pv.Condition)
	//			.Include(pv => pv.Edition)
	//			.SingleOrDefaultAsync(pv => pv.Id == newProductVariant.Id);

	//		var productVariantResponse = productVariantsMapper.Map(productVariant);

	//		return productVariantResponse;
	//	}

	//	public async Task<ProductVariantResponse?> UpdateProductVariant(long id, ProductVariantRequest productVariantRequest)
	//	{
	//		var result = await context.ProductVariants
	//			.Where((pv) => pv.Id == id)
	//			.ExecuteUpdateAsync((prodVar) =>
	//				prodVar
	//					.SetProperty((pv) => pv.Price, productVariantRequest.Price)
	//					.SetProperty((pv) => pv.ProductId, productVariantRequest.ProductId)
	//					.SetProperty((pv) => pv.ConditionId, productVariantRequest.ConditionId)
	//					.SetProperty((pv) => pv.EditionId, productVariantRequest.EditionId)
	//					);

	//		if (result > 0)
	//		{
	//			var updatedProductVariant = await context.ProductVariants
	//				.Include(pv => pv.Product)
	//				.Include(pv => pv.Condition)
	//				.Include(pv => pv.Edition)
	//				.SingleAsync(pv => pv.Id == id);

	//			var productVariantResponse = productVariantsMapper.Map(updatedProductVariant);
	//			return productVariantResponse;
	//		}
	//		else
	//		{
	//			return null;
	//		}
	//	}

	//	public async Task DeleteProductVariant(long id)
	//	{
	//		var productVariantToRemove = await context.ProductVariants.FindAsync(id);

	//		if (productVariantToRemove == null)
	//		{
	//			throw new ArgumentNullException();
	//		}
	//		else
	//		{
	//			context.ProductVariants.Remove(productVariantToRemove);
	//			await context.SaveChangesAsync();
	//		}
	//	}
	//}
}

