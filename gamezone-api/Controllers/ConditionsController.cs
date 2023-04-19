using System;
using Microsoft.AspNetCore.Mvc;
using gamezone_api.Models;
using gamezone_api.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Threading.Channels;

namespace gamezone_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConditionsController : ControllerBase
    {
        IConditionService conditionService;

        public ConditionsController(IConditionService conditionService)
        {
            this.conditionService = conditionService;
        }

        // GET: conditions
        [HttpGet]
        public async Task<ActionResult<Condition>> GetConditions()
        {
            var conditions = await conditionService.GetConditions();
            return Ok(conditions);
        }

        // GET by id: conditions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Condition?>> GetConditionById([FromRoute] int id)
        {
            var condition = await conditionService.GetConditionById(id);
            if (condition == null)
            {
                return NotFound();
            }
            return Ok(condition);
        }

        // POST: conditions
        [HttpPost]
        public async Task<ActionResult<Condition?>> CreateNewCondition([FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                var newCondition = await conditionService.CreateNewCondition(condition);

                return Ok(newCondition);
            }

        }

        // UPDATE: conditions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Condition?>> UpdateCondition([FromRoute] int id, [FromBody] Condition condition)
        {
            try
            {
                var updatedCondition = await conditionService.UpdateCondition(id, condition);

                return Ok(updatedCondition);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        // DELETE: conditions/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Condition?>> DeleteCondition([FromRoute] int id)
        {
            try
            {
                await conditionService.DeleteCondition(id);
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            catch (ArgumentException ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

