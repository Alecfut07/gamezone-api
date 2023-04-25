using System;
namespace gamezone_api.Parameters
{
	public class ProductParameters
	{
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

