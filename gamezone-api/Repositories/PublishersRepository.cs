using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class PublishersRepository
	{
		private GamezoneContext context;
		private PublishersMapper publishersMapper;

		public PublishersRepository(GamezoneContext dbContext, PublishersMapper publishersMapper)
		{
			context = dbContext;
			this.publishersMapper = publishersMapper;
		}

		public async Task<IEnumerable<PublisherResponse>> GetPublishers()
		{
			var publishers = await context.Publishers.ToListAsync();

			var publishersResponse = publishers.ConvertAll<PublisherResponse>((pub) => publishersMapper.Map(pub));
			return publishersResponse;
		}

		public async Task<PublisherResponse> GetPublisherById(int id)
		{
			var publisher = await context.Publishers.FindAsync(id);

			var publisherResponse = publishersMapper.Map(publisher);
			return publisherResponse;
		}

		public async Task<PublisherResponse> CreateNewPublisher(PublisherRequest publisherRequest)
		{
			var newPublisher = publishersMapper.Map(publisherRequest);

			context.Publishers.Add(newPublisher);
			await context.SaveChangesAsync();

			var publisherResponse = publishersMapper.Map(newPublisher);
			return publisherResponse;
		}

		public async Task<PublisherResponse> UpdatePublisher(int id, PublisherRequest publisherRequest)
		{
			var result = await context.Publishers
				.Where((pub) => pub.Id == id)
				.ExecuteUpdateAsync((pub) =>
					pub
						.SetProperty((pub) => pub.Name, publisherRequest.Name)
						);

			if (result > 0)
			{
				var updatedPublisher = await context.Publishers.FindAsync(id);

				var publisherResponse = publishersMapper.Map(updatedPublisher);
				return publisherResponse;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public async Task DeletePublisher(int id)
		{
			var publisherToDelete = await context.Publishers.FindAsync(id);

			if (publisherToDelete == null)
			{
				throw new ArgumentException();
			}
			else
			{
				context.Publishers.Remove(publisherToDelete);
				await context.SaveChangesAsync();
			}
		}
	}
}

