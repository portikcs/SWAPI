﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SWAPIHelpers;
using SWAPILogic;
using SWAPIModel;
using System;

namespace SWAPITest
{
    [TestClass]
    public class StarShipDeserializerTests
    {

        private IStarShipDeserializer _starShipDeserializer;
        private IJsonConvertWrapper<StarShipJsonResult> _jsonConvertWrapper;

        [TestInitialize]
        public void TestInit()
        {
            _jsonConvertWrapper =  Substitute.For<IJsonConvertWrapper<StarShipJsonResult>>();
            _starShipDeserializer = new StarShipDeserializer(_jsonConvertWrapper);
        }

        [TestMethod]
        public void GivenTestJson_WhenCallDeserializeStarShips_ShouldReturnMockedObject()
        {
            //arrange
            StarShipJsonResult jsonResult = new StarShipJsonResult {Count = 10};
            _jsonConvertWrapper.Deserialize(Arg.Any<string>()).Returns(jsonResult);
            var json = "Test data";
            //act
            var result = _starShipDeserializer.DeserializeStarShips(json);
            //assert
            result.Should().NotBeNull();
            result.Count.Should().BeGreaterOrEqualTo(10);
        }

        [TestMethod]
        public void GivenExceptionTRhrowingMethod_WhenCallDeserializeStarShips_ShouldThrowException()
        {
            //arrange
            _jsonConvertWrapper.Deserialize(Arg.Any<string>()).Throws(new Exception("Test"));
            var json = "Test data";
            var message = string.Empty;
            //act
            try
            {
                var result = _starShipDeserializer.DeserializeStarShips(json);
                if (result != null) message = result.Count.ToString();
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }

            //assert
            message.Should().NotBeEmpty();
            message.Should().NotBe("10");
            message.Should().Be("Test");
        }

    }
}
