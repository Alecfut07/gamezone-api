using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductVariantsController : ControllerBase
	{
		IProductVariantService productVariantService;

		public ProductVariantsController(IProductVariantService productVariantService)
		{
			this.productVariantService = productVariantService;
		}

		// GET: /productvariants
		[HttpGet]
		public async Task<ActionResult<ProductVariantResponse>> GetProductVariants()
		{
			var productVariants = await productVariantService.GetProductVariants();
			return Ok(productVariants);
		}

		// GET: /productvariants/id
		[HttpGet("{id}")]
		public async Task<ActionResult<ProductVariantResponse?>> GetProductVariantById([FromRoute] long id)
		{
			var productVariant = await productVariantService.GetProductVariantById(id);
			if (productVariant == null)
			{
				return NotFound();
			}
			return Ok(productVariant);
		}

        // POST: /productvariants
        [HttpPost]
		public async Task<ActionResult<ProductVariantResponse?>> SaveNewProductVariant([FromBody] ProductVariantRequest productVariantRequest)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			else
			{
				var newProductVariant = await productVariantService.SaveNewProductVariant(productVariantRequest);
				return Ok(newProductVariant);
			}
		}

		// PUT: /productvariants/id
		public async Task<ActionResult<ProductVariantResponse?>> UpdateProductVariant([FromRoute] long id, [FromBody] ProductVariantRequest productVariantRequest)
		{
			var updatedProductVariant = await productVariantService.UpdateProductVariant(id, productVariantRequest);
			if (updatedProductVariant == null)
			{
				return NotFound();
			}
			return Ok(updatedProductVariant);
		}

		// DELETE: /productvariants/id
		public async Task<ActionResult> DeleteProductVariant([FromRoute] long id)
		{
			try
			{
				await productVariantService.DeleteProductVariant(id);
			}
			catch(Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}

