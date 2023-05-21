using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Helpers;
using Newtonsoft.Json;
using System.IO;

namespace gamezone_api.Controllers.Admin
{
    [ApiController]
    [Route("/admin/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /products
        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetProducts()
        {
            try
            {
                var products = await _productService.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST /products
        [HttpPost]
        public async Task<ActionResult<ProductResponse?>> SaveNewProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                try
                {
                    string protocol = HttpContext.Request.Host.Host;
                    var newProduct = await _productService.SaveNewProduct(productRequest);
                    return Ok(newProduct);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // POST: admin/products/upload
        [HttpPost("upload")]
        public ActionResult<ImageResponse?> UploadImage([FromForm] ImageRequest imageRequest)
        {
            try
            {
                var newImageUploaded = _productService.UploadImage(imageRequest);
                if (newImageUploaded == null)
                {
                    return NotFound();
                }
                return Ok(newImageUploaded);
            }
            catch(ArgumentNullException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch(IOException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // PUT /products/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse?>> UpdateProduct([FromRoute] long id, [FromBody] ProductRequest productRequest)
        {
            try
            {
                var updatedProduct = await _productService.UpdateProduct(id, productRequest);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok(updatedProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE /products/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] long id)
        {
            try
            {
                await _productService.DeleteProduct(id);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
