﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Text.Json.Serialization;

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

        // CONDITIONS 
        [ForeignKey("condition_id")]
        [Required]
        [Column("condition_id")]
        [JsonPropertyName("condition_id")]
        public int ConditionId { get; set; }

        public virtual Condition? Condition { get; set; }

        // EDITIONS
        [ForeignKey("edition_id")]
        [Required]
        [Column("edition_id")]
        [JsonPropertyName("edition_id")]
        public int EditionId { get; set; }

        public virtual Edition? Edition { get; set; }
    }
}

