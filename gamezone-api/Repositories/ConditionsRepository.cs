using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
    public class ConditionsRepository
    {
        private GamezoneContext _context;

        public ConditionsRepository(GamezoneContext context)
        {
            _context = context;
        }

        public async Task<List<Condition>> GetConditions()
        {
            var conditions = await _context.Conditions.ToListAsync();
            return conditions;
        }

        public async Task<Condition?> GetConditionById(int id)
        {
            var condition = await _context.Conditions.FindAsync(id);
            return condition;
        }

        public async Task<Condition> CreateNewCondition(Condition condition)
        {
            _context.Conditions.Add(condition);
            await _context.SaveChangesAsync();

            var newCondition = await _context.Conditions.SingleAsync(c => c.Id == condition.Id);

            return newCondition;
        }

        public async Task<Condition?> UpdateCondition(int id, Condition condition)
        {
            var result = await _context.Conditions
                .Where((c) => c.Id == id)
                .ExecuteUpdateAsync((cond) =>
                    cond
                        .SetProperty((c) => c.State, condition.State)
                        );

            if (result > 0)
            {
                var updatedCondition = await _context.Conditions.FindAsync(id);
                return updatedCondition;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteCondition(int id)
        {
            var conditionToDelete = await _context.Conditions.FindAsync(id);

            if (conditionToDelete == null)
            {
                throw new KeyNotFoundException();
            }
            else
            {
                _context.Conditions.Remove(conditionToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}

