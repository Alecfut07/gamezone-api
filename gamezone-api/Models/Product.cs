using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace gamezone_api.Models
{
	public class Product
	{
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("price")]
        public decimal Price { get; set; }

        [Column("release_date")]
        public DateTime? ReleaseDate { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Required]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }

        [Required]
        [Column("update_date")]
        public DateTime UpdateDate { get; set; }
    }
}

