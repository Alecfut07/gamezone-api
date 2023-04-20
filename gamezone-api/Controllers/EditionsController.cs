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

		// GET: /editions
		[HttpGet]
		public async Task<ActionResult<Edition?>> GetEditions()
		{
			var editions = await editionService.GetEditions();
			return Ok(editions);
		}

		// GET by id: /editions/id
		[HttpGet("{id}")]
		public async Task<ActionResult<Edition?>> GetEditionById(int id)
		{
			var edtion = await editionService.GetEditionById(id);
			return edtion;
		}
	}
}

