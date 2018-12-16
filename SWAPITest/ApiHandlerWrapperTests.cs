using Microsoft.VisualStudio.TestTools.UnitTesting;
using SWAPIHelpers;
using System;
using System.Threading.Tasks;
using FluentAssertions;

namespace SWAPITest
{
    [TestClass]
    public class ApiHandlerWrapperTests
    {
        private IApiHandlerWrapper _apiHandlerWrapper;

        [TestInitialize]
        public void TestInit()
        {
            _apiHandlerWrapper = new ApiHandlerWrapper();
        }

        [TestMethod]
        public void GivenUrl_WhenCallGetApiCallResult_ShouldReturnString()
        {
            //arrange
            var url = "https://swapi.co/api/starships/";
            //act
             var result =_apiHandlerWrapper.GetApiCallResultAsync(url).Result;
            //assert
            result.Should().NotBeNullOrEmpty();
        }

        [TestMethod]
        public void GivenUrl_WhenCallGetApiCallResult_ShouldThrowException()
        {
            //arrange
            var url = "https://swapi.co/api/starships111/";
            //act
            Func<Task<string>> action = async () => await _apiHandlerWrapper.GetApiCallResultAsync(url);
            //assert
            action.Should().Throw<Exception>();
        }
    }
}
