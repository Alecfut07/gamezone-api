﻿using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Helpers;
using Newtonsoft.Json;
using NuGet.ContentModel;

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

    // GET /products/id
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductResponse?>> GetProductById([FromRoute] long id)
    {
        try
        {
            var product = await productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    // GET /products? pagenumber = 1 & pagesize = 10
    [HttpGet]
    public async Task<ActionResult<List<ProductResponse>>> GetProductsByPaging([FromQuery] ProductParameters productParameters)
    {
        try
        {
            var products = await productService.GetProductsByPaging(productParameters);
            if (products is PagedList<ProductResponse>)
            {
                var paginatedProducts = products as PagedList<ProductResponse>;
                var metadata = new
                {
                    paginatedProducts.TotalCount,
                    paginatedProducts.PageSize,
                    paginatedProducts.CurrentPage,
                    paginatedProducts.TotalPages,
                    paginatedProducts.HasPrevious,
                    paginatedProducts.HasNext,
                };

                HttpContext.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            }
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet]
    [Route("Search")]
    public async Task<ActionResult<List<ProductResponse>>> SearchProducts([FromQuery] SearchParameter searchParameter)
    {
        try
        {
            var products = await productService.SearchProducts(searchParameter);
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}

