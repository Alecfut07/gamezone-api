using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;

namespace gamezone_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    IProductService productService;

    public ProductsController(IProductService service)
    {
        productService = service;
    }

    // GET: api/product
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(productService.Get());
    }

    // GET api/product/id
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/product
    [HttpPost]
    public IActionResult Post([FromBody] Product product)
    {
        //try
        //{
        //    productService.Save(product);
        //}
        //catch (Exception ex)
        //{
        //    //return BadRequest();
        //    return StatusCode(StatusCodes.Status500InternalServerError);
        //}
        //return Ok();

        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        else
        {
            var newProduct = productService.Save(product);
            product.Id = newProduct.Id;

            return Ok(product);
            //return CreatedAtAction(nameof(Get), new { ID = product.ID }, product);
        }
    }

    // PUT api/product/id
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Product product)
    {
        productService.Update(id, product);
        return Ok();
    }

    // DELETE api/product/id
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        productService.Delete(id);
        return Ok();
    }
}

