using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Parameters
{
	public class SearchParameter
	{
        [BindProperty(Name = "q", SupportsGet = true)]
        public string? Query { get; set; } = null;
    }
}

