using System;
using gamezone_api.Models;
using gamezone_api.Networking;
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

        // GET by id: /editions/id
        [HttpGet("{id}")]
        public async Task<ActionResult<EditionResponse?>> GetEditionById([FromRoute] int id)
        {
            var edition = await editionService.GetEditionById(id);
            if (edition == null)
            {
                return NotFound();
            }
            return Ok(edition);
        }
    }
}

