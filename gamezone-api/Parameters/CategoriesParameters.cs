using System;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Parameters
{
	public class CategoriesParameters
	{
		[BindProperty(Name = "show_parents")]
        public bool ShowParents { get; set; }
	}
}

