using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
	public class ConditionService : IConditionService
	{
		private ConditionsRepository conditionsRepository;
		private ConditionsMapper conditionsMapper;

		public ConditionService(ConditionsRepository conditionsRepository, ConditionsMapper conditionsMapper)
		{
			this.conditionsRepository = conditionsRepository;
			this.conditionsMapper = conditionsMapper;
		}

		public async Task<IEnumerable<ConditionResponse?>> GetConditions()
		{
			var conditions = await conditionsRepository.GetConditions();
            var conditionsResponse = conditions.ConvertAll<ConditionResponse>((c => conditionsMapper.Map(c)));
            return conditionsResponse;
		}

		public async Task<ConditionResponse?> GetConditionById(int id)
		{
			var condition = await conditionsRepository.GetConditionById(id);
			if (condition != null)
			{
                var conditionResponse = conditionsMapper.Map(condition);
				return conditionResponse;
            }
			return null;
		}

		public async Task<ConditionResponse?> CreateNewCondition(ConditionRequest newCondition)
		{
			var createdCondition = await conditionsRepository.CreateNewCondition(newCondition);
			if (createdCondition != null)
			{
				var conditionResponse = conditionsMapper.Map(createdCondition);
				return conditionResponse;
			}
            return null;
		}

		public async Task<ConditionResponse?> UpdateCondition(int id, ConditionRequest conditionRequest)
		{
			var updatedCondition = await conditionsRepository.UpdateCondition(id, conditionRequest);
			if (updatedCondition != null)
			{
				var conditionResponse = conditionsMapper.Map(updatedCondition);
				return conditionResponse;
			}
			return null;
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

