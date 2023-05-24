using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
	public class CategoryProductVariant
	{ 
		[Key]
		public long Id { get; set; }

		[ForeignKey("category_id")]
		[Column("category_id")]
		public long CategoryId { get; set; }

		[Column("category")]
		public Category Category { get; set; }

		[ForeignKey("product_variant_id")]
		[Column("product_variant_id")]
		public long ProductVariantId { get; set; }

		[Column("product_variant")]
		public ProductVariant ProductVariant { get; set; }
	}
}

