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

        public async Task<List<Condition>> GetConditions()
        {
            var conditions = await context.Conditions.ToListAsync();
            return conditions;
        }

        public async Task<Condition?> GetConditionById(int id)
        {
            var condition = await context.Conditions.FindAsync(id);
            return condition;
        }

        public async Task<Condition?> CreateNewCondition(ConditionRequest conditionRequest)
        {
            var newCondition = conditionsMapper.Map(conditionRequest);

            context.Conditions.Add(newCondition);
            await context.SaveChangesAsync();

            return newCondition;
        }

        public async Task<Condition?> UpdateCondition(int id, ConditionRequest conditionRequest)
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
                return updatedCondition;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteCondition(int id)
        {
            var conditionToDelete = await context.Conditions.FindAsync(id);

            if (conditionToDelete == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                context.Conditions.Remove(conditionToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}

