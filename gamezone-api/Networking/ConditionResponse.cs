using gamezone_api.Models;

namespace gamezone_api.Networking
{
    public class ConditionResponse
	{
        public int Id { get; set; }

        public string State { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var conditionResponse = obj as ConditionResponse;
            return
                this.Id == conditionResponse.Id &&
                this.State == conditionResponse.State;
        }
    }
}
