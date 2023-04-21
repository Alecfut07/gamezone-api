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

        // GET: /editions
        [HttpGet]
        public async Task<ActionResult<EditionResponse?>> GetEditions()
        {
            var editions = await editionService.GetEditions();
            return Ok(editions);
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

        // POST: /editions
        [HttpPost]
        public async Task<ActionResult<EditionResponse?>> CreateNewEdition([FromBody] EditionRequest editionRequest)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            else
            {
                var newEdition = await editionService.CreateNewEdition(editionRequest);
                return Ok(newEdition);
            }
        }

        // PUT: /editions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<EditionResponse?>> UpdateEdition([FromRoute] int id, [FromBody] EditionRequest editionRequest)
        {
            try
            {
                var updatedEdition = await editionService.UpdateEdition(id, editionRequest);
                return Ok(updatedEdition);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }

        // DELETE: /editions/id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEdition([FromRoute] int id)
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

