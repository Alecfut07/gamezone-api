using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class EditionsRepository
	{
		private GamezoneContext context;
        private EditionsMapper editionsMapper;

		public EditionsRepository(GamezoneContext dbContext, EditionsMapper editionsMapper)
		{
			context = dbContext;
            this.editionsMapper = editionsMapper;

        }

		public async Task<List<Edition>> GetEditions()
		{
            var editions = await context.Editions.ToListAsync();
            return editions;
        }

		public async Task<Edition?> GetEditionById(int id)
		{
            var edition = await context.Editions.FindAsync(id);
            return edition;
        }

		public async Task<EditionResponse?> CreateNewEdition(EditionRequest editionRequest)
		{
            var newEdition = editionsMapper.Map(editionRequest);

            context.Editions.Add(newEdition);
            await context.SaveChangesAsync();

            var editionResponse = editionsMapper.Map(newEdition);
            return editionResponse;
        }

		public async Task<EditionResponse?> UpdateEdition(int id, EditionRequest editionRequest)
		{
            var result = await context.Editions
                .Where((e) => e.Id == id)
                .ExecuteUpdateAsync((edit) =>
                    edit
                        .SetProperty((e) => e.Type, editionRequest.Type)
                        );

            if (result > 0)
            {
                var updatedEdition = await context.Editions.FindAsync(id);

                var editionResponse = editionsMapper.Map(updatedEdition);
                return editionResponse;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteEdition(int id)
        {
            var editionToDelete = await context.Editions.FindAsync(id);

            if (editionToDelete == null)
            {
                throw new ArgumentException();
            }
            else
            {
                context.Editions.Remove(editionToDelete);
                await context.SaveChangesAsync();
            }
        }
	}
}

