﻿using System;
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

		public async Task<Condition?> GetConditionById(int id)
		{
			var condition = await context.Conditions.FindAsync(id);
			return condition;
		}

		public async Task<Condition?> CreateNewCondition(Condition newCondition)
		{
			context.Conditions.Add(newCondition);
			await context.SaveChangesAsync();
			return newCondition;
		}

		public async Task<Condition?> UpdateCondition(int id, Condition condition)
		{
			var conditionToUpdate = await context.Conditions.FindAsync(id);

			if (conditionToUpdate == null)
			{
				throw new ArgumentException();
			}
			else
			{
				conditionToUpdate.State = condition.State;
				await context.SaveChangesAsync();
			}
			return conditionToUpdate;
		}

		public async Task DeleteCondition(int id)
		{
			var conditionToDelete = await context.Conditions.FindAsync(id);

			if (conditionToDelete == null)
			{
				throw new ArgumentException();
			}
			else
			{
				context.Conditions.Remove(conditionToDelete);
				await context.SaveChangesAsync();
			}
		}
    }

	public interface IConditionService
	{
		Task<IEnumerable<Condition?>> GetConditions();

		Task<Condition?> GetConditionById(int id);

		Task<Condition?> CreateNewCondition(Condition newCondition);

		Task<Condition?> UpdateCondition(int id, Condition condition);

		Task DeleteCondition(int id);
	}
}
