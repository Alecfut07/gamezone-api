using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
    [Authorize]
    [ApiController]
	[Route("/admin/[controller]")]
	public class CategoriesController : ControllerBase
	{
		ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		// GET: /admin/categories
		[HttpGet]
		[AllowAnonymous]
		public async Task<ActionResult<CategoryResponse>> GetCategories()
		{
			try
			{
				var categories = await _categoryService.GetCategories();
				return Ok(categories);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		// POST: /admin/categories
		[HttpPost]
		public async Task<ActionResult<CategoryResponse>> CreateNewCategory([FromBody] CategoryRequest categoryRequest)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			else
			{
				try
				{
					var newCategory = await _categoryService.CreateNewCategory(categoryRequest);
					return Ok(newCategory);
				}
				catch (Exception ex)
				{
					return StatusCode(StatusCodes.Status500InternalServerError);
				}
			}
		}

		// UPDATE: /admin/categories
		[HttpPut("{id}")]
		public async Task<ActionResult<CategoryResponse?>> UpdateCategory([FromRoute] long id, [FromBody] CategoryRequest categoryRequest)
		{
			try
			{
				var updatedCategory = await _categoryService.UpdateCategory(id, categoryRequest);
				if (updatedCategory == null)
				{
					return NotFound();
				}
				return Ok(updatedCategory);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}

		// DELETE: /admin/categories
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteCategory([FromRoute] long id)
		{
			try
			{
				await _categoryService.DeleteCategory(id);
			}
			catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			catch (Exception ex)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}

