using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWAPIHelpers;
using SWAPILogic;
using SWAPIModel;
using System;

namespace SWAPITest
{
    [TestClass]
    public class IntegrationTests
    {

        private IStopsCalculateLogic _stopsCalculateLogic;

        [TestInitialize]
        public void TestInit()
        {
            _stopsCalculateLogic =  new StopsCalculateLogic(
                new StarShipDeserializer(new JsonConvertWrapper<StarShipJsonResult>()),
                new ApiHandlerWrapper());
        }

        [TestMethod]
        public void GivenDistanceAndUrl_WhenCallCalculateStops_ShouldReturnResult()
        {
            //arrange
            var url = "https://swapi.co/api/starships/";
            //act
            var result = _stopsCalculateLogic.CalculateStops(1000000, url).Result;
            //assert
            result.Count.Should().Be(10);
            result.Should().Contain("Y-wing:74");
        }

        [TestMethod]
        public void GivenZeroDistanceAndUrl_WhenCallCalculateStops_ShouldReturnResultWithNegativeStops()
        {
            //arrange
            var url = "https://swapi.co/api/starships/";
            //act
            var result = _stopsCalculateLogic.CalculateStops(0, url).Result;
            //assert
            result.Count.Should().Be(10);
            result.Should().Contain("Y-wing:-1");
        }

        [TestMethod]
        public void GivenDistanceAndWrongUrl_WhenCallCalculateStops_ShouldReturnThrowException()
        {
            //arrange
            var url = "https://swapi.co/api/starships1111/";
            string message = string.Empty;
            //act
            try
            {
                var result = _stopsCalculateLogic.CalculateStops(0, url).Result;
                if (result.Count > 0) message = string.Empty;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //assert
            message.Should().NotBeNullOrWhiteSpace();
        }
    }
}