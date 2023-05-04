using System;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	//public class ProductVariantService : IProductVariantService
	//{
	//	private ProductVariantsRepository productVariantsRepository;

	//	public ProductVariantService(ProductVariantsRepository productVariantsRepository)
	//	{
	//		this.productVariantsRepository = productVariantsRepository;
	//	}

	//	public async Task<IEnumerable<ProductVariantResponse>> GetProductVariants()
	//	{
	//		var productVariants = await productVariantsRepository.GetProductVariants();
	//		return productVariants;
	//	}

	//	public async Task<ProductVariantResponse?> GetProductVariantById(long id)
	//	{
	//		var productVariant = await productVariantsRepository.GetProductVariantById(id);
	//		return productVariant;
	//	}

	//	public async Task<ProductVariantResponse?> SaveNewProductVariant(ProductVariantRequest productVariantRequest)
	//	{
	//		var productVariantResponse = await productVariantsRepository.SaveNewProductVariant(productVariantRequest);
	//		return productVariantResponse;
	//	}

	//	public async Task<ProductVariantResponse?> UpdateProductVariant(long id, ProductVariantRequest productVariantRequest)
	//	{
	//		return await productVariantsRepository.UpdateProductVariant(id, productVariantRequest);
	//	}

	//	public async Task DeleteProductVariant(long id)
	//	{
	//		await productVariantsRepository.DeleteProductVariant(id);
	//	}
 //   }

	//public interface IProductVariantService
	//{
	//	Task<IEnumerable<ProductVariantResponse>> GetProductVariants();

	//	Task<ProductVariantResponse?> GetProductVariantById(long id);

	//	Task<ProductVariantResponse?> SaveNewProductVariant(ProductVariantRequest productVariantRequest);

	//	Task<ProductVariantResponse?> UpdateProductVariant(long id, ProductVariantRequest productVariantRequest);

	//	Task DeleteProductVariant(long id);
 //   }
}

