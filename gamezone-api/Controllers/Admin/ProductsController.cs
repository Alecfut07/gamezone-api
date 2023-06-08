using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Helpers;
using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace gamezone_api.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("/admin/[controller]")]
    public class ProductsController : ApplicationController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService, IUserService usersService)
            : base(usersService)
        {
            _productService = productService;
        }

        // GET: /products
        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetProducts()
        {
            try
            {
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var products = await _productService.GetProducts();
                    return Ok(products);
                }
                else
                {
                    return Forbid();
                }
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
                    var userLoggedIn = await GetLoggedInUser();
                    if (userLoggedIn.IsAdmin)
                    {
                        string protocol = HttpContext.Request.Host.Host;
                        var newProduct = await _productService.SaveNewProduct(productRequest);
                        return Ok(newProduct);
                    }
                    else
                    {
                        return Forbid();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // POST: admin/products/upload
        [HttpPost("upload")]
        public async Task<ActionResult<ImageResponse?>> UploadImage([FromForm] ImageRequest imageRequest)
        {
            try
            {
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var newImageUploaded = _productService.UploadImage(imageRequest);
                    if (newImageUploaded == null)
                    {
                        return NotFound();
                    }
                    return Ok(newImageUploaded);
                }
                else
                {
                    return Forbid();
                }
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
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var updatedProduct = await _productService.UpdateProduct(id, productRequest);
                    if (updatedProduct == null)
                    {
                        return NotFound();
                    }
                    return Ok(updatedProduct);
                }
                else
                {
                    return Forbid();
                }
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
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    await _productService.DeleteProduct(id);
                }
                else
                {
                    return Forbid();
                }
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
