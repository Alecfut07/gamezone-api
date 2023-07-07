using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace gamezone_tests.Services
{
	public class CartsServiceTest
	{
        private Mock<ILogger> _logger = new Mock<ILogger>();
        private Mock<ICartsMapper> _cartsMapper = new Mock<ICartsMapper>();
        private Mock<ICartsRepository> _cartsRepository = new Mock<ICartsRepository>();

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        /*
         * TODO:
         * Expected: <gamezone-api.Networking.CartResponse>
         * But was:  <gamezone-api.Networking.CartResponse>
         */
        [Test]
        public async Task getCart_ReturnsCart_WhenRepositorySucceeds()
        {
            string uuid = "jreioafjoirej";
            long productId = 0;
            int quantity = 0;
            ProductCacheEntry pce = new ProductCacheEntry();

            var list = new List<(long, int, ProductCacheEntry)>();

            var cartProduct = new CartProduct();

            //var cartProducts = new List<CartProduct>();

            var task = Task.FromResult(list);

            _cartsRepository.Setup(m => m.GetCart(uuid)).Returns(task);

            var cartProducts = list.ConvertAll((tuple) =>
            {
                var productId = tuple.Item1;
                var quantity = tuple.Item2;
                var productCacheEntry = tuple.Item3;
                _cartsMapper.Setup(m => m.Map(productId, quantity, pce)).Returns(cartProduct);
                return cartProduct;
            });

            var expected = new CartResponse
            {
                Products = cartProducts
            };

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            var actual = await cartsService.GetCart(uuid);

            Assert.That(actual.GetType(), Is.EqualTo(expected.GetType()));
            Assert.That(actual.Products, Is.EqualTo(expected.Products));
        }

        [Test]
        public async Task getCart_ThrowsException_WhenRepositoryFails()
        {
            string uuid = "jreioafjoirej";

            var exception = new ArgumentNullException();

            _cartsRepository.Setup(m => m.GetCart(uuid)).Throws(exception);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            Assert.ThrowsAsync<ArgumentNullException>(async () => await cartsService.GetCart(uuid));
        }

        [Test]
        public async Task addItemToCart_ItemAdded_WhenRepositorySucceeds()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            _cartsRepository.Setup(m => m.AddItemToCart(uuid, cartRequest)).Returns(Task.CompletedTask);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);
            await cartsService.AddItemToCart(uuid, cartRequest);

            _cartsRepository.Verify(m => m.AddItemToCart(uuid, cartRequest), Times.Once);
        }

        [Test]
        public async Task addItemToCart_ThrowsException_WhenRepositoryFails()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            var exception = new OperationCanceledException();

            _cartsRepository.Setup(m => m.AddItemToCart(uuid, cartRequest)).Throws(exception);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await cartsService.AddItemToCart(uuid, cartRequest));
        }

        [Test]
        public async Task updateQuantity_QuantityUpdated_WhenRepositorySucceeds()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            _cartsRepository.Setup(m => m.UpdateQuantity(uuid, cartRequest)).Returns(Task.CompletedTask);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);
            await cartsService.UpdateQuantity(uuid, cartRequest);

            _cartsRepository.Verify(m => m.UpdateQuantity(uuid, cartRequest), Times.Once);
        }

        [Test]
        public async Task updateQuantity_ThrowsException_WhenRepositoryFails()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            var exception = new Exception();

            _cartsRepository.Setup(m => m.UpdateQuantity(uuid, cartRequest)).Throws(exception);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            Assert.ThrowsAsync<Exception>(async () => await cartsService.UpdateQuantity(uuid, cartRequest));
        }

        [Test]
        public async Task removeAllItemsInCart_AllItemsRemoved_WhenRepositorySucceeds()
        {
            string uuid = "jreioafjoirej";

            _cartsRepository.Setup(m => m.RemoveAllItemsInCart(uuid)).Returns(Task.CompletedTask);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);
            await cartsService.RemoveAllItemsInCart(uuid);

            _cartsRepository.Verify(m => m.RemoveAllItemsInCart(uuid), Times.Once);
        }

        [Test]
        public async Task removeAllItemsInCart_ThrowsException_WhenRepositoryFails()
        {
            string uuid = "jreioafjoirej";

            var exception = new Exception();

            _cartsRepository.Setup(m => m.RemoveAllItemsInCart(uuid)).Throws(exception);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            Assert.ThrowsAsync<Exception>(async () => await cartsService.RemoveAllItemsInCart(uuid));
        }

        [Test]
        public async Task removeItemInCart_ItemRemoved_WhenRepositorySucceeds()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            _cartsRepository.Setup(m => m.RemoveItemInCart(uuid, cartRequest)).Returns(Task.CompletedTask);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);
            await cartsService.RemoveItemInCart(uuid, cartRequest);

            _cartsRepository.Verify(m => m.RemoveItemInCart(uuid, cartRequest), Times.Once);
        }

        [Test]
        public async Task removeItemInCart_ThrowsException_WhenRepositoryFails()
        {
            string uuid = "jreioafjoirej";
            var cartRequest = new CartRequest();

            var exception = new Exception();

            _cartsRepository.Setup(m => m.RemoveItemInCart(uuid, cartRequest)).Throws(exception);

            var cartsService = new CartsService(_logger.Object, _cartsRepository.Object, _cartsMapper.Object);

            Assert.ThrowsAsync<Exception>(async () => await cartsService.RemoveItemInCart(uuid, cartRequest));
        }
    }
}

