using System;
using gamezone_api.Models;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class EditionsController : ControllerBase
	{
		IEditionService editionService;

		public EditionsController(IEditionService editionService)
		{
			this.editionService = editionService;
		}

		// GET: editions
		[HttpGet]
		public async Task<ActionResult<Edition?>> GetEditions()
		{
			var editions = await editionService.GetEditions();
			return Ok(editions);
		}
	}
}

