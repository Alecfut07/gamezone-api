using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class ConditionsMapper : IConditionsMapper
	{
		public Condition Map(ConditionRequest conditionRequest)
		{
			return new Condition
			{
				State = conditionRequest.State
			};
		}

		public ConditionResponse Map(Condition condition)
		{
			return new ConditionResponse
			{
				Id = condition.Id,
				State = condition.State
			};
		}
	}

	public interface IConditionsMapper
	{
		Condition Map(ConditionRequest conditionRequest);

		ConditionResponse Map(Condition condition);
    }
}

