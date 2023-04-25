using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;
using gamezone_api.Networking;
using gamezone_api.Parameters;

namespace gamezone_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    // GET: /products
    //[HttpGet]
    //public async Task<ActionResult<ProductResponse>> GetProducts()
    //{
    //    var products = await productService.GetProducts();
    //    return Ok(products);
    //}

    // GET /products/id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse?>> GetProductById([FromRoute] long id)
    {
        var product = await productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    // GET /products?pagenumber=1&pagesize=10
    [HttpGet]
    public async Task<ActionResult<ProductResponse?>> GetProductsByPaging([FromQuery] ProductParameters productParameters)
    {
        var productsByPaging = await productService.GetProductsByPaging(productParameters);
        return Ok(productsByPaging);
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
        catch(Exception ex)
        {
            return NotFound();
        }
        return NoContent();
    }
}

