using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SWAPIModel;

namespace SWAPITest
{
    [TestClass]
    public class CountStopsTests
    {
        [TestMethod]
        public void GivenDistanceAndYearConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "1 year";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(11);
        }
        
        [TestMethod]
        public void GivenDistanceAndYearsConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "2 years";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(5);
        }

        [TestMethod]
        public void GivenDistanceAndMonthConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "1 month";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(138);
        }

        [TestMethod]
        public void GivenDistanceAndMonthsConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "12 months";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(11);
        }

        [TestMethod]
        public void GivenDistanceAndWeekConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "1 week";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(595);
        }

        [TestMethod]
        public void GivenDistanceAndWeeksConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "4 weeks";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(148);
        }


        [TestMethod]
        public void GivenDistanceAndDayConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "1 day";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(4166);
        }

        [TestMethod]
        public void GivenDistanceAndDaysConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "10 days";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(416);
        }


        [TestMethod]
        public void GivenDistanceAndBadTimePart_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "10 dayssss";
            _model.MGLT = 100;
            //act
            var result = _model.CountStops(100);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroCapacity_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "10 days";
            _model.MGLT = 0;
            //act
            var result = _model.CountStops(100);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroDistance_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "10 days";
            _model.MGLT = 10;
            //act
            var result = _model.CountStops(0);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroConsumable_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip _model = new StarShip();
            _model.Consumables = "0 days";
            _model.MGLT = 10;
            //act
            var result = _model.CountStops(110);
            //assert
            result.Should().Be(0);
        }
    }
}