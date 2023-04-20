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
	}
}
