using System;
using gamezone_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
	public class EditionService : IEditionService
	{
		GamezoneContext context;

		public EditionService(GamezoneContext dbContext)
		{
			context = dbContext;
		}

		public async Task<IEnumerable<Edition?>> GetEditions()
		{
			var editions = await context.Editions.ToListAsync();
			return editions;
		}
	}

	public interface IEditionService
	{
		Task<IEnumerable<Edition?>> GetEditions();
	}
}

