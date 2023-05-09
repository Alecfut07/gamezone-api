﻿using Microsoft.AspNetCore.Mvc;
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
        IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: /products
        [HttpGet]
        public async Task<ActionResult<ProductResponse>> GetProducts()
        {
            var products = await productService.GetProducts();
            return Ok(products);
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
                var newProduct = await productService.SaveNewProduct(productRequest);
                return Ok(newProduct);
            }
        }

        // POST: admin/products/upload
        [HttpPost("/upload")]
        public async Task<ActionResult<ImageResponse?>> UploadImage([FromForm] ImageRequest imageRequest)
        {
            //if (!ModelState.IsValid)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            //else
            //{
            //    var  = await productService.UploadImage(id, imageRequest);
            //    return Ok(newProduct);
            //}
            //var file = Request.Form.Files[0];

            var newImageUploaded = await productService.UploadImage(imageRequest);
            return Ok(newImageUploaded);
        }

        // PUT /products/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductResponse?>> UpdateProduct([FromRoute] long id, [FromBody] ProductRequest productRequest)
        {
            var updatedProduct = await productService.UpdateProduct(id, productRequest);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return Ok(updatedProduct);
        }

        // DELETE /products/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] long id)
        {
            try
            {
                await productService.DeleteProduct(id);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
