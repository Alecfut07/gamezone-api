using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class CategoriesController : ControllerBase
	{
		ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		// GET by id: /categories/id
		[HttpGet("{id}")]
		public async Task<ActionResult<CategoryResponse?>> GetCategoryById([FromRoute] long id)
		{
			try
			{
				var category = await _categoryService.GetCategoryById(id);
				if (category == null)
				{
					return NotFound();
				}
				return Ok(category);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}

