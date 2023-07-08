using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Moq;

namespace gamezone_tests.Mappers
{
	public class EditionsMapperTest
	{
        private Mock<IEditionsMapper> _editionsMapper = new Mock<IEditionsMapper>();

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task map_ReturnsEdition_WhenPassAEditionRequest()
        {
            var editionRequest = new EditionRequest
            {
                Type = "type"
            };

            var expected = new Edition
            {
                Type = editionRequest.Type
            };

            _editionsMapper.Setup(m => m.Map(editionRequest)).Returns(expected);

            var editionsMapper = new EditionsMapper();

            var actual = editionsMapper.Map(editionRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task map_ReturnsEditionResponse_WhenPassAEdition()
        {
            var edition = new Edition
            {
                Type = "type"
            };

            var expected = new EditionResponse
            {
                Type = edition.Type
            };

            _editionsMapper.Setup(m => m.Map(edition)).Returns(expected);

            var editionsMapper = new EditionsMapper();

            var actual = editionsMapper.Map(edition);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

