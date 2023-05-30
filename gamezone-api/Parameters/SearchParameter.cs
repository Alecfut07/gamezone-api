using System;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

namespace gamezone_api.Parameters
{
	public class SearchParameter
	{
        [BindProperty(Name = "q", SupportsGet = true)]
        public string? Name { get; set; } = null;

        [BindProperty(Name = "category", SupportsGet = true)]
        public string? Category { get; set; } = null;

        const int maxPageSize = 30;
        public int? PageNumber { get; set; } = null;

        private int? _pageSize = null;
        public int? PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }
    }
}

