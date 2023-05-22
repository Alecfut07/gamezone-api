using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace gamezone_api.Services
{
    public class EditionsService : BaseService, IEditionService
    {
        private EditionsRepository _editionsRepository;
        private EditionsMapper _editionsMapper;

        public EditionsService(ILogger logger, EditionsRepository editionsRepository, EditionsMapper editionsMapper)
            : base(logger)
        {
            _editionsRepository = editionsRepository;
            _editionsMapper = editionsMapper;
        }

        public async Task<IEnumerable<EditionResponse?>> GetEditions()
        {
            try
            {
                var editions = await _editionsRepository.GetEditions();
                var editionsResponse = editions.ConvertAll<EditionResponse>((e) => _editionsMapper.Map(e));
                return editionsResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<EditionResponse?> GetEditionById(int id)
        {
            try
            {
                var edition = await _editionsRepository.GetEditionById(id);
                if (edition != null)
                {
                    var editionResponse = _editionsMapper.Map(edition);
                    return editionResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<EditionResponse?> CreateNewEdition(EditionRequest editionRequest)
        {
            try
            {
                var newEdition = _editionsMapper.Map(editionRequest);
                var createdEdition = await _editionsRepository.CreateNewEdition(newEdition);
                var editionResponse = _editionsMapper.Map(newEdition);
                return editionResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<EditionResponse?> UpdateEdition(int id, EditionRequest editionRequest)
        {
            try
            {
                var editionToUpdate = _editionsMapper.Map(editionRequest);
                var updatedEdition = await _editionsRepository.UpdateEdition(id, editionToUpdate);
                if (updatedEdition != null)
                {
                    var editionResponse = _editionsMapper.Map(updatedEdition);
                    return editionResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task DeleteEdition(int id)
        {
            try
            {
                await _editionsRepository.DeleteEdition(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
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

