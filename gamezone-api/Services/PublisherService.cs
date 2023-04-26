using System;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
	public class PublisherService : IPublisherService
	{
		private PublishersRepository publishersRepository;

		public PublisherService(PublishersRepository publishersRepository)
		{
			this.publishersRepository = publishersRepository;
		}

		public async Task<IEnumerable<PublisherResponse?>> GetPublishers()
		{
			var publishers = await publishersRepository.GetPublishers();
			return publishers;
		}

		public async Task<PublisherResponse?> GetPublisherById(int id)
		{
			var conditionResponse = await publishersRepository.GetPublisherById(id);
			return conditionResponse;
		}

		public async Task<PublisherResponse?> CreateNewPublisher(PublisherRequest publisherRequest)
		{
			var publisherResponse = await publishersRepository.CreateNewPublisher(publisherRequest);
			return publisherResponse;
		}

		public async Task<PublisherResponse?> UpdatePublisher(int id, PublisherRequest publisherRequest)
		{
			var publisherResponse = await publishersRepository.UpdatePublisher(id, publisherRequest);
			return publisherResponse;
		}

		public async Task DeletePublisher(int id)
		{
			await publishersRepository.DeletePublisher(id);
		}
	}

	public interface IPublisherService
    {
		Task<IEnumerable<PublisherResponse?>> GetPublishers();

		Task<PublisherResponse?> GetPublisherById(int id);

		Task<PublisherResponse?> CreateNewPublisher(PublisherRequest publisherRequest);

		Task<PublisherResponse?> UpdatePublisher(int id, PublisherRequest publisherRequest);

		Task DeletePublisher(int id);
	}
}

