using System;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("/api/admin/[controller]")]
    public class EditionsController : ApplicationController
    {
        IEditionService _editionService;

        public EditionsController(IEditionService editionService, IUserService usersService)
            : base(usersService)
        {
            _editionService = editionService;
        }

        // GET: /editions
        [HttpGet]
        public async Task<ActionResult<EditionResponse?>> GetEditions()
        {
            try
            {
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var editions = await _editionService.GetEditions();
                    return Ok(editions);
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
                try
                {
                    var userLoggedIn = await GetLoggedInUser();
                    if (userLoggedIn.IsAdmin)
                    {
                        var newEdition = await _editionService.CreateNewEdition(editionRequest);
                        return Ok(newEdition);
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

        // PUT: /editions/id
        [HttpPut("{id}")]
        public async Task<ActionResult<EditionResponse?>> UpdateEdition([FromRoute] int id, [FromBody] EditionRequest editionRequest)
        {
            try
            {
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    var updatedEdition = await _editionService.UpdateEdition(id, editionRequest);
                    return Ok(updatedEdition);
                }
                else
                {
                    return Forbid();
                }
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
                var userLoggedIn = await GetLoggedInUser();
                if (userLoggedIn.IsAdmin)
                {
                    await _editionService.DeleteEdition(id);
                }
                else
                {
                    return Forbid();
                }
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

