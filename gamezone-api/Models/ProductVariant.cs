using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class ProductVariant
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("price")]
		public decimal Price { get; set; }

		[ForeignKey("product_id")]
		[Column("product_id")]
		public long ProductId { get; set; }

		[ForeignKey("condition_id")]
		[Column("condition_id")]
		public int ConditionId { get; set; }

		[ForeignKey("edition_id")]
		[Column("edition_id")]
		public int EditionId { get; set; }

		public virtual Product Product { get; set; }

		public virtual Condition Condition { get; set; }

		public virtual Edition Edition { get; set; }
	}
}

