using System;
namespace gamezone_api.Services
{
	public abstract class BaseService
	{
		protected ILogger _logger;

		public BaseService(ILogger logger)
		{
			_logger = logger;
		}
	}
}

