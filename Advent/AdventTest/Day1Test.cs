using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day1Test
    {
        [TestMethod]
        public void TwoNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 514579;

            var day1 = new Day1();
            var results = day1.FindExpenseTwo(_input);

            var actualResult = results.Item1 * results.Item2;

            actualResult.Should().Be(expectedResult);
        }

        [TestMethod]
        public void ThreeNumbersShouldAddAndReturnCorrectResult()
        {
            var expectedResult = 241861950;

            var day1 = new Day1();
            var results = day1.FindExpenseThree(_input);

            var actualResult = results.Item1 * results.Item2 * results.Item3;

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
