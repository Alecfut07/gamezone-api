using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
    public class ConditionsService : BaseService, IConditionService
    {
        private ConditionsRepository _conditionsRepository;
        private IConditionsMapper _conditionsMapper;

        public ConditionsService(ILogger logger, ConditionsRepository conditionsRepository, IConditionsMapper conditionsMapper)
            : base(logger)
        {
            _conditionsRepository = conditionsRepository;
            _conditionsMapper = conditionsMapper;
        }

        public async Task<IEnumerable<ConditionResponse?>> GetConditions()
        {
            try
            {
                var conditions = await _conditionsRepository.GetConditions();
                var conditionsResponse = conditions.ConvertAll<ConditionResponse>((c => _conditionsMapper.Map(c)));
                return conditionsResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<ConditionResponse?> GetConditionById(int id)
        {
            try
            {
                var condition = await _conditionsRepository.GetConditionById(id);
                if (condition != null)
                {
                    var conditionResponse = _conditionsMapper.Map(condition);
                    return conditionResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<ConditionResponse?> CreateNewCondition(ConditionRequest conditionRequest)
        {
            try
            {
                var newCondition = _conditionsMapper.Map(conditionRequest);
                var createdCondition = await _conditionsRepository.CreateNewCondition(newCondition);
                var conditionResponse = _conditionsMapper.Map(createdCondition);
                return conditionResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<ConditionResponse?> UpdateCondition(int id, ConditionRequest conditionRequest)
        {
            try
            {
                var conditionToUpdate = _conditionsMapper.Map(conditionRequest);
                var updatedCondition = await _conditionsRepository.UpdateCondition(id, conditionToUpdate);
                if (updatedCondition != null)
                {
                    var conditionResponse = _conditionsMapper.Map(updatedCondition);
                    return conditionResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task DeleteCondition(int id)
        {
            try
            {
                await _conditionsRepository.DeleteCondition(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
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

