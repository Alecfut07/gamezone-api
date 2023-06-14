using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("/api/admin/[controller]")]
    public class ConditionsController : ApplicationController
    {
        IConditionService _conditionService;

        public ConditionsController(IConditionService conditionService, IUserService usersService)
            : base(usersService)
        {
            _conditionService = conditionService;
        }

        // GET: /conditions
        [HttpGet]
        public async Task<ActionResult<ConditionResponse>> GetConditions()
        {
            try
            {
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var conditions = await _conditionService.GetConditions();
                    return Ok(conditions);
                }
                else
                {
                    return Forbid();
                }
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
                    var userLoggedIn = await GetLoggedInUser();
                    if (userLoggedIn.IsAdmin)
                    {
                        var newCondition = await _conditionService.CreateNewCondition(condition);
                        return Ok(newCondition);
                    }
                    else
                    {
                        return Forbid();
                    }
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
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var updatedCondition = await _conditionService.UpdateCondition(id, conditionRequest);
                    if (updatedCondition == null)
                    {
                        return NotFound();
                    }
                    return Ok(updatedCondition);
                }
                else
                {
                    return Forbid();
                }
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
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    await _conditionService.DeleteCondition(id);
                }
                else
                {
                    return Forbid();
                }
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

