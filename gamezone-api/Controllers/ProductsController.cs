using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;

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

    // GET: api/product
    [HttpGet]
    public async Task<ActionResult<Product>> GetProducts()
    {
        var products = await productService.GetProducts();
        return Ok(products);
    }

    // GET api/product/id
    [HttpGet("{id}")]
    public async Task<ActionResult<Product?>> GetProductById([FromRoute] long id)
    {
        var product = await productService.GetProductById(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    // POST api/product
    [HttpPost]
    public async Task<ActionResult<Product?>> SaveNewProduct([FromBody] Product product)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        else
        {
            var newProduct = await productService.SaveNewProduct(product);

            return Ok(newProduct);
        }
    }

    // PUT api/product/id
    [HttpPut("{id}")]
    public async Task<ActionResult<Product?>> UpdateProduct([FromRoute] long id, [FromBody] Product product)
    {
        var updatedProduct = await productService.UpdateProduct(id, product);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(updatedProduct);
    }

    // DELETE api/product/id
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct([FromRoute] long id)
    {
        try
        {
            await productService.DeleteProduct(id);
        } catch(Exception ex)
        {
            return NotFound();
        }
        return NoContent();
    }
}

