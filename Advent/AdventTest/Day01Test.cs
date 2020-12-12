using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day01Test
    {
        [TestMethod]
        public void TwoNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 514579;

            var day1 = new Day01();
            var actualResult = day1.ExpenseTwoResult(_input);

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ThreeNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 241861950;

            var day1 = new Day01();
            var actualResult = day1.ExpenseThreeResult(_input);

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
