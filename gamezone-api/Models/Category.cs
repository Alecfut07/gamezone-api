using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
	public class Category
	{
		[Key]
		[Column("id")]
		public long Id { get; set; }

		[Column("name")]
		public string Name { get; set; }

		[ForeignKey("parent_category_id")]
		[Column("parent_category_id")]
		public long? ParentCategoryId { get; set; }

		//[Column("parent_category")]
		//public Category ParentCategory { get; set; }

		//public List<Category> SubCategories { get; set; }

		[Column("create_date")]
		public DateTime CreateDate { get; set; }

		[Column("update_date")]
		public DateTime UpdateDate { get; set; }

        public virtual Category? ParentCategory { get; set; }

		public ICollection<CategoryProductVariant> CategoriesProductVariants { get; set; }
	}
}

