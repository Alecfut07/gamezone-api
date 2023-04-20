using System;
using gamezone_api.Models;
using gamezone_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
	public class ConditionService : IConditionService
	{
		private ConditionsRepository conditionsRepository;

		public ConditionService(ConditionsRepository conditionsRepository)
		{
			this.conditionsRepository = conditionsRepository;
		}

		public async Task<IEnumerable<Condition?>> GetConditions()
		{
			var conditions = await conditionsRepository.GetConditions();
			return conditions;
		}

		public async Task<Condition?> GetConditionById(int id)
		{
			var condition = await conditionsRepository.GetConditionById(id);
			return condition;
		}

		public async Task<Condition?> CreateNewCondition(Condition newCondition)
		{
			var createdCondition = await conditionsRepository.CreateNewCondition(newCondition);
			return createdCondition;
		}

		public async Task<Condition?> UpdateCondition(int id, Condition condition)
		{
			return await conditionsRepository.UpdateCondition(id, condition);
		}

		public async Task DeleteCondition(int id)
		{
			await conditionsRepository.DeleteCondition(id);
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

