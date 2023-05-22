using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
    public class PublishersService : BaseService, IPublisherService
    {
        private PublishersRepository _publishersRepository;
        private PublishersMapper _publishersMapper;

        public PublishersService(ILogger logger, PublishersRepository publishersRepository)
            : base(logger)
        {
            _publishersRepository = publishersRepository;
        }

        public async Task<IEnumerable<PublisherResponse?>> GetPublishers()
        {
            try
            {
                var publishers = await _publishersRepository.GetPublishers();
                var publishersResponse = publishers.ConvertAll<PublisherResponse>((pub) => _publishersMapper.Map(pub));
                return publishersResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PublisherResponse?> GetPublisherById(int id)
        {
            try
            {
                var publisher = await _publishersRepository.GetPublisherById(id);
                if (publisher != null)
                {
                    var publisherResponse = _publishersMapper.Map(publisher);
                    return publisherResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PublisherResponse?> CreateNewPublisher(PublisherRequest publisherRequest)
        {
            try
            {
                var newPublisher = _publishersMapper.Map(publisherRequest);
                var createdPublisher = await _publishersRepository.CreateNewPublisher(newPublisher);
                var publisherResponse = _publishersMapper.Map(createdPublisher);
                return publisherResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<PublisherResponse?> UpdatePublisher(int id, PublisherRequest publisherRequest)
        {
            try
            {
                var publisherToUpdate = _publishersMapper.Map(publisherRequest);
                var updatedPublisher = await _publishersRepository.UpdatePublisher(id, publisherToUpdate);
                if (updatedPublisher != null)
                {
                    var publisherResponse = _publishersMapper.Map(updatedPublisher);
                    return publisherResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task DeletePublisher(int id)
        {
            try
            {
                await _publishersRepository.DeletePublisher(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
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

