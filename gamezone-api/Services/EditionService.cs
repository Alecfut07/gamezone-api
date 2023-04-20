using System;
using gamezone_api.Models;
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

		public async Task<IEnumerable<Edition?>> GetEditions()
		{
			var editions = await editionsRepository.GetEditions();
			return editions;
		}

		public async Task<Edition?> GetEditionById(int id)
		{
			var edition = await editionsRepository.GetEditionById(id);
			return edition;
		}

		public async Task<Edition?> CreateNewEdition(Edition newEdition)
		{
			return await editionsRepository.CreateNewEdition(newEdition);
		}

		public async Task<Edition?> UpdateEdition(int id, Edition edition)
		{
			return await editionsRepository.UpdateEdition(id, edition);
		}

		public async Task DeleteEdition(int id)
		{
			await editionsRepository.DeleteEdition(id); 
		}
	}

	public interface IEditionService
	{
		Task<IEnumerable<Edition?>> GetEditions();

		Task<Edition?> GetEditionById(int id);

		Task<Edition?> CreateNewEdition(Edition newEdition);

		Task<Edition?> UpdateEdition(int id, Edition edition);

		Task DeleteEdition(int id);
	}
}

