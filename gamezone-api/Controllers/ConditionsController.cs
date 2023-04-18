using System;
using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ConditionsController : ControllerBase
	{
		IConditionService conditionService;

		public ConditionsController(IConditionService service)
		{
			conditionService = service;
		}

		// GET: conditions
		[HttpGet]
		public async Task<ActionResult<Condition>> GetConditions()
		{
			var conditions = await conditionService.GetConditions();
			return Ok(conditions);
		}

		// GET by id: conditions/id
		//[HttpGet("{id}")]
		//public IActionResult GetConditionById([FromRoute] int id)
		//{
		//	return Ok();
		//}

		// POST: conditions
		//[HttpGet]
		//public IActionResult CreateNewCondition([FromBody] Condition condition)
		//{
		//	return Ok();
		//}

		// UPDATE: conditions/id
		//[HttpPut("{id}")]
		//public IActionResult UpdateCondition([FromRoute] int id, [FromBody] Condition condition)
		//{
		//	return Ok();
		//}

		// DELETE: conditions/id
		//[HttpDelete("{id}")]
		//public IActionResult DeleteCondition([FromRoute] int id)
		//{
		//	return Ok();
		//}
    }
}

