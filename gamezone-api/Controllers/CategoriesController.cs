using System;
using gamezone_api.Networking;
using gamezone_api.Parameters;
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

        [HttpGet("{id}/{parentCategoryId}")]
        public async Task<ActionResult<CategoryResponse?>> GetCategoryWithSubcategory([FromRoute] long id, [FromRoute] long parentCategoryId)
        {
            try
            {
                var categoryWithSubCategory = await _categoryService.GetCategoryWithSubcategory(id, parentCategoryId);
                if (categoryWithSubCategory == null)
                {
                    return NotFound();
                }
                return Ok(categoryWithSubCategory);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
		public async Task<ActionResult<List<CategoryResponse>>> GetFilterCategories([FromQuery] CategoriesParameters categoriesParameters)
		{
			try
			{
				var categories = await _categoryService.GetFilterCategories(categoriesParameters);
				if (categories == null)
				{
					return NotFound();
				}
				return Ok(categories);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}

