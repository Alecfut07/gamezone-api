using System;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Parameters
{
	public class ProductsCollectionParameters
	{
        [BindProperty(Name = "collection", SupportsGet = true)]
        public string? Collection { get; set; } = null;
    }
}

