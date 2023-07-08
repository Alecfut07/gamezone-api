using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class Condition
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Required]
		[Column("state")]
		public string State { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var condition = obj as Condition;
            return
                this.Id == condition.Id &&
                this.State == condition.State;
        }
    }
}
