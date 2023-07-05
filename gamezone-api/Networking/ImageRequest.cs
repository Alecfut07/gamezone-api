using System;
using System.ComponentModel.DataAnnotations;

namespace gamezone_api.Networking
{
	public class ImageRequest
	{
		//[FileExtensions(Extensions = "jpg,jpeg")]
        public IFormFile? Image { get; set; }
	}
}

