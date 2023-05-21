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
            try
            {
                var conditions = await conditionService.GetConditions();
                return Ok(conditions);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
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
                try
                {
                    var newCondition = await conditionService.CreateNewCondition(condition);
                    if (newCondition == null)
                    {
                        return NotFound();
                    }
                    return Ok(newCondition);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }

        }

        // UPDATE: /conditions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<ConditionResponse?>> UpdateCondition([FromRoute] int id, [FromBody] ConditionRequest conditionRequest)
        {
            try
            {
                var updatedCondition = await conditionService.UpdateCondition(id, conditionRequest);
                if (updatedCondition == null)
                {
                    return NotFound();
                }
                return Ok(updatedCondition);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
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
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

