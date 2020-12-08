using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day8Test
    {
        private Day8 _day8;

        [TestInitialize]
        public void Setup()
        {
            _day8 = new Day8();
        }

        [TestMethod]
        public void SampleCodeFailsOnFive()
        {
            var expected = 5;

            var actual = _day8.AccumulateAtCrash(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleCodeExitsWithEightAfterChange()
        {
            var expected = 8;

            var actual = _day8.FixAndAccumulator(_input);

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
