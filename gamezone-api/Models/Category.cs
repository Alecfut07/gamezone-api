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

		[Column("handle")]
		public string Handle { get; set; }

		[Column("create_date")]
		public DateTime CreateDate { get; set; }

		[Column("update_date")]
		public DateTime UpdateDate { get; set; }

        public virtual Category? ParentCategory { get; set; }

		public ICollection<CategoryProductVariant> CategoriesProductVariants { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (object.ReferenceEquals(this, obj)) { return true; }

            var category = obj as Category;
            return
                this.Id == category.Id &&
                this.Name == category.Name &&
                this.ParentCategoryId == category.ParentCategoryId &&
                this.Handle == category.Handle &&
				this.CreateDate == category.CreateDate &&
				this.UpdateDate == category.UpdateDate &&
				this.ParentCategory == category.ParentCategory &&
				this.CategoriesProductVariants == category.CategoriesProductVariants;
        }
    }
}

