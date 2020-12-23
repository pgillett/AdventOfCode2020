using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day23Test
    {
        private Day23 _day23;

        [TestInitialize]
        public void Setup()
        {
            _day23 = new Day23();
        }

        [TestMethod]
        public void SampleDataAfter10Moves()
        {
            var expected = "92658374";

            var actual = _day23.TextFrom1(_input, 10);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleDataAfter100Moves()
        {
            var expected = "67384529";

            var actual = _day23.TextFrom1(_input, 100);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleDataRight2After10000000Moves()
        {
            var expected = 149245887792L;

            var actual = _day23.RightMultiply(_input, 10000000);

            actual.Should().Be(expected);
        }
        
        private string _input = @"389125467";
    }
}
