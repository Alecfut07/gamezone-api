using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
    public class EditionRequest
	{
		[Required]
		public string Type { get; set; }
	}
}

