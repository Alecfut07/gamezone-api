using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using Moq;

namespace gamezone_tests.Mappers
{
	public class CartsMapperTest
	{
        private Mock<ICartsMapper> _cartsMapper = new Mock<ICartsMapper>();

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task map_ReturnsCartProduct_WhenPassAList()
        {
            long productId = 0;
            int quantity = 0;
            ProductCacheEntry pce = new ProductCacheEntry();

            var expected = new CartProduct();

            _cartsMapper.Setup(m => m.Map(productId, quantity, pce)).Returns(expected);

            var cartsMapper = new CartsMapper();

            var actual = cartsMapper.Map(productId, quantity, pce);

            //Assert.That(actual, Is.EqualTo(expected));
            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
        }
    }
}

