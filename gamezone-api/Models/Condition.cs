using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

		[JsonIgnore]
		public virtual ICollection<Product> Products { get; set; }
	}
}

