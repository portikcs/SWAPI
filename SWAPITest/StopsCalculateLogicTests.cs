﻿using System.Collections.Generic;
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
        public void GivenDistanceAndUrl_WhenCallCalculateStops_ShouldReturnValidResult()
        {
            //arrange
            StarShipJsonResult jsonResult = new StarShipJsonResult
            {
                Count = 10,
                Results = new List<StarShip> {new StarShip {Name = "Test", Consumables = "6 years", Mglt = 100}}
            };
            var json = "Test data";
            _apiHandlerWrapper.GetApiCallResultAsync(Arg.Any<string>()).Returns(json);
            _starShipDeserializer.DeserializeStarShips(Arg.Any<string>()).Returns(jsonResult);
            //act
            var result = _stopsCalculateLogic.CalculateStops(100000, "Test").Result;
            //assert
            result.Should().NotBeNull();
            result.Count.Should().Be(1);
        }

        [TestMethod]
        public void GivenDistanceAndUrlEmptyJson_WhenCallCalculateStops_ShouldReturnEmptyResult()
        {
            //arrange
            StarShipJsonResult jsonResult = new StarShipJsonResult
            {
                Count = 10,
                Results = new List<StarShip> {new StarShip {Name = "Test", Consumables = "6 years", Mglt = 100}}
            };
            var json = "";
            _apiHandlerWrapper.GetApiCallResultAsync(Arg.Any<string>()).Returns(json);
            _starShipDeserializer.DeserializeStarShips(Arg.Any<string>()).Returns(jsonResult);
            //act
            var result = _stopsCalculateLogic.CalculateStops(100000, "Test").Result;
            //assert
            result.Count.Should().Be(0);
        }


        [TestMethod]
        public void GivenDistanceAndUrlEmptyShipList_WhenCallCalculateStops_ShouldReturnEmptyResult()
        {
            //arrange
            StarShipJsonResult jsonResult = new StarShipJsonResult {Count = 10, Results = new List<StarShip>()};
            var json = "Test data";
            _apiHandlerWrapper.GetApiCallResultAsync(Arg.Any<string>()).Returns(json);
            _starShipDeserializer.DeserializeStarShips(Arg.Any<string>()).Returns(jsonResult);
            //act
            var result = _stopsCalculateLogic.CalculateStops(100000, "Test").Result;
            //assert
            result.Count.Should().Be(0);
        }

    }
}