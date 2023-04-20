using System;
using gamezone_api.Models;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class EditionsRepository
	{
		private GamezoneContext context;

		public EditionsRepository(GamezoneContext dbContext)
		{
			context = dbContext;
		}

		public async Task<IEnumerable<Edition>> GetEditions()
		{
            var editions = await context.Editions.ToListAsync();
            return editions;
        }

		public async Task<Edition?> GetEditionById(int id)
		{
            var edition = await context.Editions.FindAsync(id);
            return edition;
        }

		public async Task<Edition?> CreateNewEdition(Edition newEdition)
		{
            context.Editions.Add(newEdition);
            await context.SaveChangesAsync();
            return newEdition;
        }

		public async Task<Edition?> UpdateEdition(int id, Edition edition)
		{
            var editionToUpdate = await context.Editions.FindAsync(id);

            if (editionToUpdate == null)
            {
                throw new ArgumentException();
            }
            else
            {
                editionToUpdate.Type = edition.Type;
                await context.SaveChangesAsync();
            }

            return editionToUpdate;
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

