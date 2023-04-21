using System;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
	public class EditionService : IEditionService
	{
		private EditionsRepository editionsRepository;

		public EditionService(EditionsRepository editionsRepository)
		{
			this.editionsRepository = editionsRepository;
		}

		public async Task<IEnumerable<EditionResponse?>> GetEditions()
		{
			var editions = await editionsRepository.GetEditions();
			return editions;
		}

		public async Task<EditionResponse?> GetEditionById(int id)
		{
			var edition = await editionsRepository.GetEditionById(id);
			return edition;
		}

		public async Task<EditionResponse?> CreateNewEdition(EditionRequest editionRequest)
		{
			return await editionsRepository.CreateNewEdition(editionRequest);
		}

		public async Task<EditionResponse?> UpdateEdition(int id, EditionRequest editionRequest)
		{
			return await editionsRepository.UpdateEdition(id, editionRequest);
		}

		public async Task DeleteEdition(int id)
		{
			await editionsRepository.DeleteEdition(id); 
		}
	}

	public interface IEditionService
	{
		Task<IEnumerable<EditionResponse?>> GetEditions();

		Task<EditionResponse?> GetEditionById(int id);

		Task<EditionResponse?> CreateNewEdition(EditionRequest newEdition);

		Task<EditionResponse?> UpdateEdition(int id, EditionRequest editionRequest);

		Task DeleteEdition(int id);
	}
}

