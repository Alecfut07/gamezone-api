using System;
using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
	public class CategoryRequest
	{
		[Required]
		public string Name { get; set; }
	}
}

