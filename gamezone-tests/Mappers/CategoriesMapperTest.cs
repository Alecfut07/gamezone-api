using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Moq;

namespace gamezone_tests.Mappers
{
	public class CategoriesMapperTest
	{
        private Mock<ICategoriesMapper> _categoriesMapper = new Mock<ICategoriesMapper>();

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task map_ReturnsCategory_WhenPassACategoryRequest()
        {
            var categoryRequest = new CategoryRequest
            {
                Name = "name",
                ParentCategoryId = 1,
                Handle = "handle"
            };

            var expected = new Category
            {
                Name = categoryRequest.Name,
                Handle = categoryRequest.Handle,
                ParentCategoryId = categoryRequest.ParentCategoryId
            };

            _categoriesMapper.Setup(m => m.Map(categoryRequest)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(categoryRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task map_ReturnsListCategoryResponse_WhenPassACategoriesDictionary()
        {
            var category = new Category
            {
                Name = "name",
                ParentCategoryId = 1,
                Handle = "handle",
                CreateDate = new DateTime(),
                UpdateDate = new DateTime()
            };

            var subcategories = new List<Category>
            {
                category
            };

            var categoriesDictionary = new Dictionary<Category, List<Category>>
            {
                { category, subcategories }
            };

            var subcategoryResponse = new SubCategoryResponse
            {
                Id = 0,
                Name = "name",
                Handle = "handle",
                //CreateDate = DateTime.Now,
                //UpdateDate = DateTime.Now,
                //CreateDate = new DateTime(),
                //UpdateDate = new DateTime(),
                ParentCategoryId = 1
            };

            var subcategoriesResponses = new List<SubCategoryResponse>
            {
                subcategoryResponse
            };

            var categoryResponse = new CategoryResponse
            {
                Id = 0,
                Name = "name",
                Handle = "handle",
                //CreateDate = DateTime.Now,
                //UpdateDate = DateTime.Now,
                CreateDate = category.CreateDate,
                UpdateDate = category.UpdateDate,
                ParentCategoryId = 1,
                //SubCategories = new List<SubCategoryResponse>()
                SubCategories = subcategoriesResponses
            };

            var expected = new List<CategoryResponse>
            {
                categoryResponse
            };

            _categoriesMapper.Setup(m => m.Map(categoriesDictionary)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(categoriesDictionary);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task map_ReturnsCategoryResponse_WhenPassACategoryAndSubcategories()
        {
            var category = new Category
            {
                Name = "name",
                ParentCategoryId = 1,
                Handle = "handle",
                CreateDate = new DateTime(),
                UpdateDate = new DateTime()
            };

            var subcategories = new List<Category>
            {
                category
            };

            var subcategoryResponse = new SubCategoryResponse
            {
                Id = 0,
                Name = "name",
                Handle = "handle",
                ParentCategoryId = 1
            };

            var subcategoriesResponses = new List<SubCategoryResponse>
            {
                subcategoryResponse
            };

            var expected = new CategoryResponse
            {
                Id = 0,
                Name = "name",
                Handle = "handle",
                CreateDate = category.CreateDate,
                UpdateDate = category.UpdateDate,
                ParentCategoryId = 1,
                SubCategories = subcategoriesResponses
            };

            _categoriesMapper.Setup(m => m.Map(category, subcategories)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(category, subcategories);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task map_ReturnsSubCategoryResponse_WhenPassASubcategory()
        {
            var subcategory = new Category
            {
                Name = "name",
                ParentCategoryId = 1,
                Handle = "handle",
                CreateDate = new DateTime(),
                UpdateDate = new DateTime()
            };

            var expected = new SubCategoryResponse
            {
                Name = subcategory.Name,
                Handle = subcategory.Handle,
                CreateDate = subcategory.CreateDate,
                UpdateDate = subcategory.UpdateDate,
                ParentCategoryId = subcategory.ParentCategoryId,
            };

            _categoriesMapper.Setup(m => m.Map(subcategory)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(subcategory);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }
    }
}

