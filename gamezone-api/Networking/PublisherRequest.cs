using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
    public class PublisherRequest
	{
		[Required]
		public string Name { get; set; }
	}
}

