using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
	[ApiController]
	[Route("/admin/[controller]")]
	public class CategoriesController : ControllerBase
	{
		private ILogger _logger;
		ICategoryService categoryService;

		public CategoriesController(ILogger logger, ICategoryService categoryService)
		{
			_logger = logger;
			this.categoryService = categoryService;
		}

		// GET: /admin/categories
		[HttpGet]
		public async Task<ActionResult<CategoryResponse>> GetCategories()
		{
			try
			{
				var categories = await categoryService.GetCategories();
				return Ok(categories);
			}
			catch (Exception ex)
			{
				_logger.LogError($"Something went wrong: {ex}");
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}
	}
}

