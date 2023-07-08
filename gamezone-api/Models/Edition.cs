using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class Edition
	{
		[Key]
		[Column("id")]
		public int Id { get; set; }

		[Required]
		[Column("type")]
		public string Type { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var edition = obj as Edition;
            return
                this.Id == edition.Id &&
                this.Type == edition.Type;
        }
    }
}

