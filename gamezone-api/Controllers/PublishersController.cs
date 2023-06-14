using System;
using gamezone_api.Networking;
using gamezone_api.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class PublishersController : ControllerBase
	{
		IPublisherService publisherService;

		public PublishersController(IPublisherService publisherService)
		{
			this.publisherService = publisherService;
		}

		// GET: /publishers
		[HttpGet]
		public async Task<ActionResult<PublisherResponse>> GetPublishers()
		{
			var publishers = await publisherService.GetPublishers();
			return Ok(publishers);
		}

		// GET by id: /publishers/id
		[HttpGet("{id}")]
		public async Task<ActionResult<PublisherResponse>> GetPublisherById([FromRoute] int id)
		{
			var publisher = await publisherService.GetPublisherById(id);
			if (publisher == null)
			{
				return NotFound();
			}
			return Ok(publisher);
		}

		// POST: /publishers
		[HttpPost]
		public async Task<ActionResult<PublisherResponse>> CreateNewPublisher([FromBody] PublisherRequest publisherRequest)
		{
			if (!ModelState.IsValid)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			else
			{
				var newPublisher = await publisherService.CreateNewPublisher(publisherRequest);

				return Ok(newPublisher);
			}
		}

		// PUT: /publishers/id
		[HttpPut("{id}")]
		public async Task<ActionResult<PublisherResponse>> UpdatePublisher([FromRoute] int id, [FromBody] PublisherRequest publisherRequest)
		{
			try
			{
				var updatedPublisher = await publisherService.UpdatePublisher(id, publisherRequest);
				return Ok(updatedPublisher);
			}
			catch (ArgumentException ex)
			{
				return NotFound();
			}
		}

		// DELETE: /publishers/id
		[HttpDelete("{id}")]
		public async Task<ActionResult<PublisherResponse>> DeletePublisher([FromRoute] int id)
		{
			try
			{
				await publisherService.DeletePublisher(id);
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

