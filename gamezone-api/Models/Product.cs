using System;
using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Models
{
	public class Product
	{
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        [Required]
        public DateTime UpdateDate { get; set; }
    }
}

