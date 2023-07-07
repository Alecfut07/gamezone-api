using System;
using System.IO;
using gamezone_api.Helpers;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using gamezone_api.Parameters;
using gamezone_api.Repositories;
using gamezone_api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace gamezone_tests.Services
{
    public class ProductsServiceTest
    {
        private Mock<ILogger> _logger = new Mock<ILogger>();
        private Mock<IProductsMapper> _productsMapper = new Mock<IProductsMapper>();
        private Mock<IProductsRepository> _productsRepository = new Mock<IProductsRepository>();

        [SetUp]
        public void SetUp()
        {
            var task = Task.FromResult(new List<Product>());
            _productsRepository.Setup(m => m.GetProducts()).Returns(task);
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task getProducts_ReturnsProducts_WhenRepositorySucceeds()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var task = Task.FromResult(products);
            _productsRepository.Setup(m => m.GetProducts()).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(productResponse);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProducts();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task getProducts_ThrowsException_WhenRepositoryFails()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var task = Task.FromResult(products);
            var exception = new OperationCanceledException();
            _productsRepository.Setup(m => m.GetProducts()).Throws(exception);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.GetProducts());
        }

        [Test]
        public async Task getProductById_ReturnsProduct_WhenRepositorySucceeds()
        {
            long id = 0;
            var product = new Product();
            var productResponse = new ProductResponse();

            var task = Task.FromResult(product);
            _productsRepository.Setup(m => m.GetProductById(id)).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(productResponse);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductById(id);

            Assert.That(actual, Is.EqualTo(productResponse));
        }

        [Test]
        public async Task getProductById_ReturnsNull_WhenRepositoryCouldNotFindProduct()
        {
            long id = 0;
            var product = new Product();

            var task = Task.FromResult<Product?>(null);
            _productsRepository.Setup(m => m.GetProductById(id)).Returns(task);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductById(id);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task getProductById_ThrowsException_WhenRepositoryFails()
        {
            long id = 0;
            var product = new Product();
            var productResponse = new ProductResponse();

            var task = Task.FromResult(product);
            var exception = new OperationCanceledException();
            _productsRepository.Setup(m => m.GetProductById(id)).Throws(exception);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.GetProductById(id));
        }

        [Test]
        public async Task getProductByPaging_ReturnsProducts_WhenRepositorySucceeds()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var productResponses = new List<ProductResponse>
            {
                productResponse
            };
            var pageNumber = 1;
            var pageSize = 10;
            var productParameters = new ProductParameters();
            productParameters.PageNumber = pageNumber;
            productParameters.PageSize = pageSize;

            var expected = PagedList<ProductResponse>.ToPagedList(
                productResponses,
                0,
                pageNumber,
                pageSize
                );

            //var taskPagedList = Task.FromResult(productsByPaging);
            var task = Task.FromResult(products);
            _productsRepository.Setup(m => m.GetProductsByPaging(productParameters)).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(productResponse);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductsByPaging(productParameters);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task getProductsByPaging_ReturnsEmptyList_WhenPageNumberIsNull()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var productParameters = new ProductParameters();
            productParameters.PageNumber = null;
            productParameters.PageSize = 10;

            var task = Task.FromResult(products);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductsByPaging(productParameters);

            var actualPagedList = new PagedList<ProductResponse>();

            Assert.Multiple(() =>
            {
                Assert.That(productParameters.PageNumber, Is.Null);
                Assert.That(actual, Is.EqualTo(new PagedList<ProductResponse>()));
            });
        }

        [Test]
        public async Task getProductsByPaging_ReturnsEmptyList_WhenPageSizeIsNull()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var productParameters = new ProductParameters();
            productParameters.PageNumber = 1;
            productParameters.PageSize = null;

            var task = Task.FromResult(products);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductsByPaging(productParameters);

            var actualPagedList = new PagedList<ProductResponse>();

            Assert.Multiple(() =>
            {
                Assert.That(productParameters.PageSize, Is.Null);
                Assert.That(actual, Is.EqualTo(new PagedList<ProductResponse>()));
            });
        }

        [Test]
        public async Task getProductsByPaging_ThrowsException_WhenRepositoryFails()
        {
            var productParameters = new ProductParameters();
            productParameters.PageNumber = 1;
            productParameters.PageSize = 10;

            var exception = new OperationCanceledException();
            _productsRepository.Setup(m => m.GetProductsByPaging(productParameters)).Throws(exception);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.GetProductsByPaging(productParameters));
        }

        [Test]
        public async Task getProductsByCollection_ReturnsProducts_WhenRepositorySucceeds()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };

            var task = Task.FromResult(products);
            _productsRepository.Setup(m => m.GetProductsByCollection()).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(productResponse);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.GetProductsByCollection();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task getProductsByCollection_ThrowsException_WhenRepositoryFails()
        {
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var task = Task.FromResult(products);
            var exception = new OperationCanceledException();
            _productsRepository.Setup(m => m.GetProductsByCollection()).Throws(exception);
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.GetProductsByCollection());
        }

        [Test]
        public async Task searchProducts_ReturnsProducts_WhenRepositorySucceeds()
        {
            int count = 0;
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var searchParameters = new SearchParameter();
            searchParameters.Name = "Zelda";
            searchParameters.PageNumber = 1;
            searchParameters.PageSize = 1;

            int pageNumber = (int)searchParameters.PageNumber;
            int pageSize = (int)searchParameters.PageSize;

            var productsByPaging = PagedList<ProductResponse>.ToPagedList(
                expected,
                0,
                pageNumber,
                pageSize
                );

            var task = Task.FromResult((count, products));
            _productsRepository.Setup(m => m.SearchProducts(searchParameters)).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(productResponse);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.SearchProducts(searchParameters);

            Assert.That(actual, Is.EqualTo(productsByPaging));
        }

        [Test]
        public async Task searchProducts_ReturnsEmptyList_WhenNameIsNull()
        {
            int count = 0;
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var searchParameters = new SearchParameter();
            searchParameters.Name = null;
            searchParameters.PageNumber = 1;
            searchParameters.PageSize = 10;

            var task = Task.FromResult((count, products));
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.SearchProducts(searchParameters);

            var actualPagedList = new PagedList<ProductResponse>();

            Assert.Multiple(() =>
            {
                Assert.That(searchParameters.Name, Is.Null);
                Assert.That(actual, Is.EqualTo(new PagedList<ProductResponse>()));
            });
        }

        [Test]
        public async Task searchProducts_ReturnsEmptyList_WhenPageNumberIsNull()
        {
            int count = 0;
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var searchParameters = new SearchParameter();
            searchParameters.Name = "Mario";
            searchParameters.PageNumber = null;
            searchParameters.PageSize = 10;

            var task = Task.FromResult((count, products));
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.SearchProducts(searchParameters);

            var actualPagedList = new PagedList<ProductResponse>();

            Assert.Multiple(() =>
            {
                Assert.That(searchParameters.PageNumber, Is.Null);
                Assert.That(actual, Is.EqualTo(new PagedList<ProductResponse>()));
            });
        }

        [Test]
        public async Task searchProducts_ReturnsEmptyList_WhenPageSizeIsNull()
        {
            int count = 0;
            var product = new Product();
            var products = new List<Product>
            {
                product
            };
            var productResponse = new ProductResponse();
            var expected = new List<ProductResponse>
            {
                productResponse
            };
            var searchParameters = new SearchParameter();
            searchParameters.Name = "Mario";
            searchParameters.PageNumber = 1;
            searchParameters.PageSize = null;

            var task = Task.FromResult((count, products));
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.SearchProducts(searchParameters);

            var actualPagedList = new PagedList<ProductResponse>();

            Assert.Multiple(() =>
            {
                Assert.That(searchParameters.PageSize, Is.Null);
                Assert.That(actual, Is.EqualTo(new PagedList<ProductResponse>()));
            });
        }

        [Test]
        public async Task searchProducts_ThrowsException_WhenRepositoryFails()
        {
            var searchParameters = new SearchParameter();
            searchParameters.Name = "Zelda";
            searchParameters.PageNumber = 1;
            searchParameters.PageSize = 10;

            var exception = new OperationCanceledException();
            _productsRepository.Setup(m => m.SearchProducts(searchParameters)).Throws(exception);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.SearchProducts(searchParameters));
        }

        [Test]
        public async Task saveNewProduct_ReturnsProducts_WhenRepositorySucceeds()
        {
            long id = 0;
            var productRequest = new ProductRequest();
            var product = new Product();
            var expected = new ProductResponse();

            _productsMapper.Setup(m => m.Map(productRequest, id)).Returns(product);

            var task = Task.FromResult(product);

            _productsRepository.Setup(m => m.SaveNewProduct(product)).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(expected);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.SaveNewProduct(productRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task saveNewProduct_ThrowsException_WhenRepositoryFails()
        {
            long id = 0;
            var productRequest = new ProductRequest();
            var product = new Product();

            _productsMapper.Setup(m => m.Map(productRequest, id)).Returns(product);

            var exception = new OperationCanceledException();

            _productsRepository.Setup(m => m.SaveNewProduct(product)).Throws(exception);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.SaveNewProduct(productRequest));
        }

        [Test]
        public async Task uploadImage_ReturnsNull_WhenFileIsNull()
        {
            ImageRequest imageRequest = new ImageRequest
            {
                Image = null
            };
            var file = imageRequest.Image;

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.Throws<ArgumentNullException>(() => productsService.UploadImage(imageRequest));
        }

        [Test]
        public async Task uploadImage_ReturnsNull_WhenFileLengthIsZero()
        {
            var file = new Mock<IFormFile>();
            file.SetupGet(m => m.Length).Returns(0);
            ImageRequest imageRequest = new ImageRequest
            {
                Image = file.Object
            };

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = productsService.UploadImage(imageRequest);

            Assert.That(actual, Is.Null);
        }

        [Test]
        public async Task updateProduct_ReturnsProduct_WhenRepositorySucceeds()
        {
            long id = 0;
            var productRequest = new ProductRequest();
            var product = new Product();
            var expected = new ProductResponse();

            _productsMapper.Setup(m => m.Map(productRequest, id)).Returns(product);

            var task = Task.FromResult(product);

            _productsRepository.Setup(m => m.UpdateProduct(id, product)).Returns(task);
            _productsMapper.Setup(m => m.Map(product)).Returns(expected);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            var actual = await productsService.UpdateProduct(id, productRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task updateProduct_ReturnsNull_WhenProductIsNull()
        {
            long id = 0;
            var productRequest = new ProductRequest();
            var product = new Product();

            _productsMapper.Setup(m => m.Map(productRequest, id)).Returns(product);

            var task = Task.FromResult<Product?>(null);

            _productsRepository.Setup(m => m.UpdateProduct(id, product)).Returns(task);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<KeyNotFoundException>(async () => await productsService.UpdateProduct(id, productRequest));
        }

        [Test]
        public async Task updateProduct_ThrowsException_WhenRepositoryFails()
        {
            long id = 0;
            var productRequest = new ProductRequest();
            var product = new Product();

            _productsMapper.Setup(m => m.Map(productRequest, id)).Returns(product);

            var exception = new OperationCanceledException();

            _productsRepository.Setup(m => m.UpdateProduct(id, product)).Throws(exception);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.UpdateProduct(id, productRequest));
        }

        [Test]
        public async Task deleteProduct_ProductDeleted_WhenRepositorySucceeds()
        {
            // DELETE PRODUCT
            long id = 1;
            //var task = new Mock<Task>();
            //var task = Task.FromResult(default(object));
            //var task = Task.FromResult("System.Threading.Tasks.VoidTaskResult");
            //	"System.Threading.Tasks.VoidTaskResult"
            //var task = Task.CompletedTask;

            //_productsRepository.Setup(m => m.DeleteProduct(id)).Returns(task);

            //_productsRepository.Verify(m => m.DeleteProduct(id));
            //var test1 = task;

            //_productsRepository.Setup(m => m.DeleteProduct(id));

            //var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            //var actual = productsService.DeleteProduct(id);

            //Assert.That(actual, Is.EqualTo());

            // Arrange
            _productsRepository.Setup(m => m.DeleteProduct(id)).Returns(Task.CompletedTask);

            // Act
            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);
            await productsService.DeleteProduct(id);

            // Assert
            _productsRepository.Verify(m => m.DeleteProduct(id), Times.Once);
        }

        [Test]
        public async Task deleteProduc_ThrowsException_WhenRepositoryFails()
        {
            long id = 1;
            var exception = new OperationCanceledException();

            _productsRepository.Setup(m => m.DeleteProduct(id)).Throws(exception);

            var productsService = new ProductsService(_logger.Object, _productsRepository.Object, _productsMapper.Object);

            Assert.ThrowsAsync<OperationCanceledException>(async () => await productsService.DeleteProduct(id));
        }
    }
}

