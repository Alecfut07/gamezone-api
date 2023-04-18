using System;
using gamezone_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
	public class ConditionService : IConditionService
	{
		public GamezoneContext context;

		public ConditionService(GamezoneContext dbContext)
		{
			context = dbContext;
		}

		public async Task<IEnumerable<Condition?>> GetConditions()
		{
			var conditions = await context.Conditions.ToListAsync();
			return conditions;
		}
	}

	public interface IConditionService
	{
		Task<IEnumerable<Condition?>> GetConditions();
	}
}

