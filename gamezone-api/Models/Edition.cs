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
	}
}

