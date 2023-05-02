using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gamezone_api.Models
{
    public class Product
	{
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Column("image_url")]
        public string ImageURL { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [ForeignKey("condition_id")]
        [Column("condition_id")]
        public int ConditionId { get; set; }

        [ForeignKey("edition_id")]
        [Column("edition_id")]
        public int EditionId { get; set; }

        public virtual Condition Condition { get; set; }

        public virtual Edition Edition { get; set; }

        public virtual VideoGame VideoGame { get; set; }
    }
}
