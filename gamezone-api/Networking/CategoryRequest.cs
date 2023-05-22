using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class CategoryRequest
	{
		[Required]
		public string Name { get; set; }

		[JsonPropertyName("parent_category_id")]
		public long? ParentCategoryId { get; set; }

	}
}

