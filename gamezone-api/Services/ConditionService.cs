using System;
using gamezone_api.Models;
using gamezone_api.Networking;
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

		public async Task<IEnumerable<ConditionResponse?>> GetConditions()
		{
			var conditions = await conditionsRepository.GetConditions();
			return conditions;
		}

		public async Task<ConditionResponse?> GetConditionById(int id)
		{
			var condition = await conditionsRepository.GetConditionById(id);
			return condition;
		}

		public async Task<ConditionResponse?> CreateNewCondition(ConditionRequest newCondition)
		{
			var createdCondition = await conditionsRepository.CreateNewCondition(newCondition);
			return createdCondition;
		}

		public async Task<ConditionResponse?> UpdateCondition(int id, ConditionRequest conditionRequest)
		{
			return await conditionsRepository.UpdateCondition(id, conditionRequest);
		}

		public async Task DeleteCondition(int id)
		{
			await conditionsRepository.DeleteCondition(id);
		}
    }

	public interface IConditionService
	{
		Task<IEnumerable<ConditionResponse?>> GetConditions();

		Task<ConditionResponse?> GetConditionById(int id);

		Task<ConditionResponse?> CreateNewCondition(ConditionRequest newCondition);

		Task<ConditionResponse?> UpdateCondition(int id, ConditionRequest condition);

		Task DeleteCondition(int id);
	}
}

