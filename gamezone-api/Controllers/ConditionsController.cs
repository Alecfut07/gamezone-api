using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

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

        // GET by id: /conditions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ConditionResponse?>> GetConditionById([FromRoute] int id)
        {
            var condition = await conditionService.GetConditionById(id);
            if (condition == null)
            {
                return NotFound();
            }
            return Ok(condition);
        }
    }
}

