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
            var categoryRequest = new CategoryRequest();

            var expected = new Category();

            _categoriesMapper.Setup(m => m.Map(categoryRequest)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(categoryRequest);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }

        [Test]
        public async Task map_ReturnsListCategoryResponse_WhenPassACategoriesDictionary()
        {
            var categoriesDictionary = new Dictionary<Category, List<Category>>();

            var expected = new List<CategoryResponse>();

            _categoriesMapper.Setup(m => m.Map(categoriesDictionary)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(categoriesDictionary);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }

        [Test]
        public async Task map_ReturnsCategoryResponse_WhenPassACategoryAndSubcategories()
        {
            var category = new Category();
            var subcategories = new List<Category>();

            var expected = new CategoryResponse();

            _categoriesMapper.Setup(m => m.Map(category, subcategories)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(category, subcategories);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }

        [Test]
        public async Task map_ReturnsSubCategoryResponse_WhenPassASubcategory()
        {
            var subcategory = new Category();

            var expected = new SubCategoryResponse();

            _categoriesMapper.Setup(m => m.Map(subcategory)).Returns(expected);

            var categoriesMapper = new CategoriesMapper();

            var actual = categoriesMapper.Map(subcategory);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }
    }
}

