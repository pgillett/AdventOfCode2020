using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day08Test
    {
        private Day08 _day08;

        [TestInitialize]
        public void Setup()
        {
            _day08 = new Day08();
        }

        [TestMethod]
        public void SampleCodeFailsOnFive()
        {
            var expected = 5;

            var actual = _day08.AccumulateAtCrash(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleCodeExitsWithEightAfterChange()
        {
            var expected = 8;

            var actual = _day08.FixAndAccumulator(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
    }
}
