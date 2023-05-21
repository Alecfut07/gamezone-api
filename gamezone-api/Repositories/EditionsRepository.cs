using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Repositories
{
	public class EditionsRepository
	{
		private GamezoneContext _context;

		public EditionsRepository(GamezoneContext context)
		{
            _context = context;

        }

		public async Task<List<Edition>> GetEditions()
		{
            var editions = await _context.Editions.ToListAsync();
            return editions;
        }

		public async Task<Edition?> GetEditionById(int id)
		{
            var edition = await _context.Editions.FindAsync(id);
            return edition;
        }

		public async Task<Edition> CreateNewEdition(Edition edition)
		{
            _context.Editions.Add(edition);
            await _context.SaveChangesAsync();

            var newEdition = await _context.Editions.SingleAsync(e => e.Id == edition.Id);

            return newEdition;
        }

		public async Task<Edition?> UpdateEdition(int id, Edition edition)
		{
            var result = await _context.Editions
                .Where((e) => e.Id == id)
                .ExecuteUpdateAsync((edit) =>
                    edit
                        .SetProperty((e) => e.Type, edition.Type)
                        );

            if (result > 0)
            {
                var updatedEdition = await _context.Editions.FindAsync(id);
                return updatedEdition;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public async Task DeleteEdition(int id)
        {
            var editionToDelete = await _context.Editions.FindAsync(id);

            if (editionToDelete == null)
            {
                throw new ArgumentException();
            }
            else
            {
                _context.Editions.Remove(editionToDelete);
                await _context.SaveChangesAsync();
            }
        }
	}
}

