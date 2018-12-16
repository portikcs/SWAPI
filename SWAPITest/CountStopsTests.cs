using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            StarShip model = new StarShip {Consumables = "1 year", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(11);
        }
        
        [TestMethod]
        public void GivenDistanceAndYearsConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "2 years", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(5);
        }

        [TestMethod]
        public void GivenDistanceAndMonthConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "1 month", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(138);
        }

        [TestMethod]
        public void GivenDistanceAndMonthsConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "12 months", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(11);
        }

        [TestMethod]
        public void GivenDistanceAndWeekConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "1 week", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(595);
        }

        [TestMethod]
        public void GivenDistanceAndWeeksConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "4 weeks", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(148);
        }


        [TestMethod]
        public void GivenDistanceAndDayConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "1 day", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(4166);
        }

        [TestMethod]
        public void GivenDistanceAndDaysConsumable_WhenCallCountStops_ShouldReturnValidResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "10 days", Mglt = 100};
            //act
            var result = model.CountStops(10000000);
            //assert
            result.Should().BeGreaterThan(0);
            result.Should().Be(416);
        }


        [TestMethod]
        public void GivenDistanceAndBadTimePart_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "10 dayssss", Mglt = 100};
            //act
            var result = model.CountStops(100);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroCapacity_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "10 days", Mglt = 0};
            //act
            var result = model.CountStops(100);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroDistance_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "10 days", Mglt = 10};
            //act
            var result = model.CountStops(0);
            //assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void GivenDistanceAndZeroConsumable_WhenCallCountStops_ShouldReturnZeroResult()
        {
            //arrange
            StarShip model = new StarShip {Consumables = "0 days", Mglt = 10};
            //act
            var result = model.CountStops(110);
            //assert
            result.Should().Be(0);
        }
    }
}