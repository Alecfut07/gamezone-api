using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
    [ApiController]
    [Route("/admin/[controller]")]
    public class ConditionsController : ControllerBase
    {
        IConditionService conditionService;

        public ConditionsController(IConditionService conditionService)
        {
            this.conditionService = conditionService;
        }

        // GET: /conditions
        [HttpGet]
        public async Task<ActionResult<ConditionResponse>> GetConditions()
        {
            var conditions = await conditionService.GetConditions();
            return Ok(conditions);
        }

        // POST: /conditions
        [HttpPost]
        public async Task<ActionResult<ConditionResponse?>> CreateNewCondition([FromBody] ConditionRequest condition)
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

        // UPDATE: /conditions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ConditionResponse?>> UpdateCondition([FromRoute] int id, [FromBody] ConditionRequest conditionRequest)
        {
            try
            {
                var updatedCondition = await conditionService.UpdateCondition(id, conditionRequest);

                return Ok(updatedCondition);
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        // DELETE: /conditions/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCondition([FromRoute] int id)
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

