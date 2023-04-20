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
        public async Task<ActionResult<Edition?>> GetEditionById([FromRoute] int id)
        {
            var edition = await editionService.GetEditionById(id);
            if (edition == null)
            {
                return NotFound();
            }
            return Ok(edition);
        }

        // POST: /editions
        [HttpPost]
        public async Task<ActionResult<Edition?>> CreateNewEdition([FromBody] Edition edition)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                var newEdition = await editionService.CreateNewEdition(edition);
                return Ok(newEdition);
            }
        }

        // PUT: /editions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<Edition?>> UpdateEdition([FromRoute] int id, [FromBody] Edition edition)
        {
            try
            {
                var updatedEdition = await editionService.UpdateEdition(id, edition);
                return Ok(updatedEdition);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE: /editions/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Edition?>> DeleteEdition([FromRoute] int id)
        {
            try
            {
                await editionService.DeleteEdition(id);
            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
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

