using Advent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace AdventTest
{
    [TestClass]
    public class Day17Test
    {
        private Day17 _day17;

        [TestInitialize]
        public void Setup()
        {
            _day17 = new Day17();
        }

        [TestMethod]
        public void AfterSixCycles112CubesAreActive()
        {
            var expected = 112;

            var actual = _day17.Active(3, _input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void AfterSixCycles848CubesAreActive()
        {
            var expected = 848;

            var actual = _day17.Active(4, _input);

            actual.Should().Be(expected);
        }

        private string _input = @".#.
..#
###";
    }
}
