using System;
using System.Text.Json.Serialization;
using gamezone_api.Models;

namespace gamezone_api.Networking
{
	public class CategoryResponse
	{
		public long Id { get; set; }

		public string Name { get; set; }

		[JsonPropertyName("create_date")]
		public DateTime CreateDate { get; set; }

		[JsonPropertyName("update_date")]
		public DateTime UpdateDate { get; set; }

		[JsonPropertyName("parent_category_id")]
		public long? ParentCategoryId { get; set; }
    }
}

