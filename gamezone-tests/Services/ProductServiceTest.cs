using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace gamezone_tests.Services
{
	public class ProductServiceTest
	{
        [Test]
        public async Task getProductsReturnsProducts()
        {
            var expected = new List<Product>
            {
                new Product()
            };
            var task = Task.FromResult(expected);
            var logger = new Mock<ILogger>();
            var productsRepository = new Mock<IProductsRepository>();
            productsRepository.Setup((m) => m.GetProducts()).Returns(task);
            var productsMapper = new Mock<ProductsMapper>();
            var productService = new ProductsService(logger.Object, productsRepository.Object, productsMapper.Object);

            var actual = await productService.GetProducts();

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

