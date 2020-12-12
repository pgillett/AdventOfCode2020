using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day11Test
    {
        private Day11 _day11;

        [TestInitialize]
        public void Setup()
        {
            _day11 = new Day11();
        }

        [TestMethod]
        public void SampleDataStabalizesAt37()
        {
            var expected = 37;

            var actual = _day11.SeatsAtEquilibriumNear(_input);

            actual.Should().Be(expected);

        }

        [TestMethod]
        public void SampleDataStabalizesAt26()
        {
            var expected = 26;

            var actual = _day11.SeatsAtEquilibriumFurther(_input);

            actual.Should().Be(expected);

        }

        private string _input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";


    }
}
