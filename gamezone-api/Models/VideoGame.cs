using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
	public class VideoGame
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[ForeignKey("product_id")]
		[Column("product_id")]
		public long ProductId { get; set;}

		public Product Product { get; set; }

		[ForeignKey("publisher_id")]
		[Column("publisher_id")]
		public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }
    }
}

