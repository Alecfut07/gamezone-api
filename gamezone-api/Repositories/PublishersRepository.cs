using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class PublishersRepository
	{
		private GamezoneContext _context;

		public PublishersRepository(GamezoneContext context)
		{
            _context = context;
		}

		public async Task<List<Publisher>> GetPublishers()
		{
			var publishers = await _context.Publishers.ToListAsync();
			return publishers;
		}

		public async Task<Publisher?> GetPublisherById(int id)
		{
			var publisher = await _context.Publishers.FindAsync(id);
			return publisher;
		}

		public async Task<Publisher> CreateNewPublisher(Publisher publisher)
		{
			_context.Publishers.Add(publisher);
			await _context.SaveChangesAsync();

			var newPublisher = await _context.Publishers.SingleAsync(p => p.Id == publisher.Id);
			return newPublisher;
		}

		public async Task<Publisher?> UpdatePublisher(int id, Publisher publisher)
		{
			var result = await _context.Publishers
				.Where((pub) => pub.Id == id)
				.ExecuteUpdateAsync((pub) =>
					pub
						.SetProperty((pub) => pub.Name, publisher.Name)
						);

			if (result > 0)
			{
				var updatedPublisher = await _context.Publishers.FindAsync(id);
				return updatedPublisher;
			}
			else
			{
				throw new ArgumentException();
			}
		}

		public async Task DeletePublisher(int id)
		{
			var publisherToDelete = await _context.Publishers.FindAsync(id);

			if (publisherToDelete == null)
			{
				throw new KeyNotFoundException();
			}
			else
			{
                _context.Publishers.Remove(publisherToDelete);
				await _context.SaveChangesAsync();
			}
		}
	}
}

