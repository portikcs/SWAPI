using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SWAPIHelpers;
using SWAPILogic;
using SWAPIModel;

namespace SWAPITest
{
    [TestClass]
    public class StopsCalculateLogicTests
    {
        private IStarShipDeserializer _starShipDeserializer;
        private IApiHandlerWrapper _apiHandlerWrapper;
        private IStopsCalculateLogic _stopsCalculateLogic;

        [TestInitialize]
        public void TestInit()
        {
            _apiHandlerWrapper = Substitute.For<IApiHandlerWrapper>();
            _starShipDeserializer = Substitute.For<IStarShipDeserializer>();
            _stopsCalculateLogic = new StopsCalculateLogic(_starShipDeserializer, _apiHandlerWrapper);
        }

        [TestMethod]
        public void GivenTestJson_WhenCallDeserializeStarShips_ShouldReturnMockedObject()
        {
            //arrange
            StarShipJsonResult _jsonResult = new StarShipJsonResult();
            _jsonResult.Count = 10;
            _starShipDeserializer.DeserializeStarShips(Arg.Any<string>()).Returns(_jsonResult);
            var json = "Test data";
            //act
            var result = _starShipDeserializer.DeserializeStarShips(json);
            //assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(10);
        }
    }
}