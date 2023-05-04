using System;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
    [ApiController]
    [Route("/admin/[controller]")]
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

