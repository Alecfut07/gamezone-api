using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
    public class ConditionsRepository
    {
        private GamezoneContext context;
        private ConditionsMapper conditionsMapper;

        public ConditionsRepository(GamezoneContext dbContext, ConditionsMapper conditionsMapper)
        {
            context = dbContext;
            this.conditionsMapper = conditionsMapper;
        }

        public async Task<IEnumerable<ConditionResponse>> GetConditions()
        {
            var conditions = await context.Conditions.ToListAsync();

            var conditionsResponse = conditions.ConvertAll<ConditionResponse>((c => conditionsMapper.Map(c)));
            return conditionsResponse;
        }

        public async Task<ConditionResponse?> GetConditionById(int id)
        {
            var condition = await context.Conditions.FindAsync(id);

            var conditionsResponse = conditionsMapper.Map(condition);
            return conditionsResponse;
        }

        public async Task<ConditionResponse?> CreateNewCondition(ConditionRequest conditionRequest)
        {
            var newCondition = conditionsMapper.Map(conditionRequest);

            context.Conditions.Add(newCondition);
            await context.SaveChangesAsync();

            var conditionResponse = conditionsMapper.Map(newCondition);
            return conditionResponse;
        }

        public async Task<ConditionResponse?> UpdateCondition(int id, ConditionRequest conditionRequest)
        {
            var result = await context.Conditions
                .Where((c) => c.Id == id)
                .ExecuteUpdateAsync((cond) =>
                    cond
                        .SetProperty((c) => c.State, conditionRequest.State)
                        );

            if (result > 0)
            {
                var updatedCondition = await context.Conditions.FindAsync(id);

                var conditionResponse = conditionsMapper.Map(updatedCondition);
                return conditionResponse;
            }
            else
            {
                throw new ArgumentException();
            }

            //var conditionToUpdate = await context.Conditions.FindAsync(id);

            //if (conditionToUpdate == null)
            //{
            //    throw new ArgumentException();
            //}
            //else
            //{
            //    conditionToUpdate.State = condition.State;
            //    await context.SaveChangesAsync();

            //}
            //return conditionToUpdate;
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
}

