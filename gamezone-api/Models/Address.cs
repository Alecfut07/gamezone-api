using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class Address
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("line_1")]
		public string Line1 { get; set; }

		[Column("line_2")]
		public string Line2 { get; set; }

		[Column("zip_code")]
		public string ZipCode { get; set; }

		[Column("state")]
		public string State { get; set; }

		[Column("city")]
		public string City { get; set; }

		[Column("country")]
		public string Country { get; set; }
	}
}

