using System;
using gamezone_api.Mappers;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Repositories;

namespace gamezone_api.Services
{
    public class CategoriesService : BaseService, ICategoryService
    {
        private CategoriesRepository _categoriesRepository;
        private CategoriesMapper _categoriesMapper;

        public CategoriesService(ILogger logger, CategoriesRepository categoriesRepository, CategoriesMapper categoriesMapper)
            : base(logger)
        {
            _categoriesRepository = categoriesRepository;
            _categoriesMapper = categoriesMapper;
        }

        public async Task<IEnumerable<CategoryResponse>> GetCategories()
        {
            try
            {
                var categories = await _categoriesRepository.GetCategories();
                var categoriesResponse = categories.ConvertAll<CategoryResponse>((c) => _categoriesMapper.Map(c));
                return categoriesResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<CategoryResponse?> GetCategoryById(long id)
        {
            try
            {
                var category = await _categoriesRepository.GetCategoryById(id);
                if (category != null)
                {
                    var categoryResponse = _categoriesMapper.Map(category);
                    return categoryResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<List<CategoryResponse>> GetFilterCategories(CategoriesParameters categoriesParameters)
        {
            try
            {
                bool showParents = categoriesParameters.ShowParents;
                if (showParents == true)
                {
                    var parentCategories = await _categoriesRepository.GetParentCategories();
                    var categoryResponse = parentCategories.ConvertAll<CategoryResponse>((c) => _categoriesMapper.Map(c));
                    return categoryResponse;
                }
                else
                {
                    var subCategories = await _categoriesRepository.GetSubCategories();
                    var categoryResponse = subCategories.ConvertAll<CategoryResponse>((c) => _categoriesMapper.Map(c));
                    return categoryResponse;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }


        public async Task<CategoryResponse?> CreateNewCategory(CategoryRequest categoryRequest)
        {
            try
            {
                var newCategory = _categoriesMapper.Map(categoryRequest);
                var createdCategory = await _categoriesRepository.CreateNewCategory(newCategory);
                var categoryResponse = _categoriesMapper.Map(createdCategory);
                return categoryResponse;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task<CategoryResponse?> UpdateCategory(long id, CategoryRequest categoryRequest)
        {
            try
            {
                var categoryToUpdate = _categoriesMapper.Map(categoryRequest);
                var updatedCategory = await _categoriesRepository.UpdateCategory(id, categoryToUpdate);
                if (updatedCategory != null)
                {
                    var categoryResponse = _categoriesMapper.Map(updatedCategory);
                    return categoryResponse;
                }
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }

        public async Task DeleteCategory(long id)
        {
            try
            {
                await _categoriesRepository.DeleteCategory(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, null);
                throw;
            }
        }
    }

    public interface ICategoryService
    {
        Task<IEnumerable<CategoryResponse>> GetCategories();

        Task<CategoryResponse?> GetCategoryById(long id);

        Task<List<CategoryResponse>> GetFilterCategories(CategoriesParameters categoriesparameters);

        Task<CategoryResponse?> CreateNewCategory(CategoryRequest categoryRequest);

        Task<CategoryResponse?> UpdateCategory(long id, CategoryRequest categoryRequest);

        Task DeleteCategory(long id);
    }
}

