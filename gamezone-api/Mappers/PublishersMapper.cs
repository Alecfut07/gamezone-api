using System;
using gamezone_api.Models;
using gamezone_api.Networking;

namespace gamezone_api.Mappers
{
	public class PublishersMapper
	{
		public Publisher Map(PublisherRequest publisherRequest)
		{
			return new Publisher
			{
				Name = publisherRequest.Name
			};
		}

		public PublisherResponse Map(Publisher publisher)
		{
			return new PublisherResponse
			{
				Id = publisher.Id,
				Name = publisher.Name
			};
		}
	}
}

