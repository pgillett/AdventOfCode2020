using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day01Test
    {
        private Day01 _day01;

        [TestInitialize]
        public void Setup()
        {
            _day01 = new Day01();
        }

        [TestMethod]
        public void TwoNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 514579;

            var actualResult = _day01.ExpenseTwoResult(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ThreeNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 241861950;

            var actualResult = _day01.ExpenseThreeResult(_input);

            actualResult.Should().Be(expectedResult);
        }

        private string _input = @"1721
979
366
299
675
1456";
    }
}
