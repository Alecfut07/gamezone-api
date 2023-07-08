using System;
using gamezone_api.Mappers;
using gamezone_api.Models;
using gamezone_api.Networking;
using Moq;

namespace gamezone_tests.Mappers
{
	public class ConditionsMapperTest
	{
        private Mock<IConditionsMapper> _conditionsMapper = new Mock<IConditionsMapper>();

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public async Task map_ReturnsCondition_WhenPassAConditionRequest()
        {
            var conditionRequest = new ConditionRequest
            {
                State = "state"
            };

            var expected = new Condition
            {
                State = conditionRequest.State
            };

            _conditionsMapper.Setup(m => m.Map(conditionRequest)).Returns(expected);

            var conditionsMapper = new ConditionsMapper();

            var actual = conditionsMapper.Map(conditionRequest);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public async Task map_ReturnsConditionResponse_WhenPassACondition()
        {
            var condition = new Condition
            {
                State = "state"
            };

            var expected = new ConditionResponse
            {
                State = condition.State
            };

            _conditionsMapper.Setup(m => m.Map(condition)).Returns(expected);

            var conditionsMapper = new ConditionsMapper();

            var actual = conditionsMapper.Map(condition);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}

