using System;
using System.Text.Json.Serialization;

namespace gamezone_api.Networking
{
	public class ImageResponse
	{
		[JsonPropertyName("image_key")]
		public string ImageKey { get; set; }
	}
}

