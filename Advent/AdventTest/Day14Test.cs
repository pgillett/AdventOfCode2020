using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day14Test
    {
        private Day14 _day14;

        [TestInitialize]
        public void Setup()
        {
            _day14=new Day14();
        }

        [TestMethod]
        [DataRow(8, 64)]
        [DataRow(7, 101)]
        public void SampleInputLeavesMemoryCorrect(int memory, int expectedValue)
        {
            var actual = _day14.ValueAtLocation(_input1, memory);

            actual.Should().Be(expectedValue);
        }

        [TestMethod]
        public void SumOfMemoryAfterSampleIs165()
        {
            var expected = 165;
            var actual = _day14.SumOfMemory(_input1);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SumOfFloatingMemoryAfterSampleIs208()
        {
            var expected = 208;
            var actual = _day14.SumOfFloatingMemory(_input2);

            actual.Should().Be(expected);
        }

        private string _input1 = @"mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
mem[8] = 11
mem[7] = 101
mem[8] = 0";

        private string _input2 = @"mask = 000000000000000000000000000000X1001X
mem[42] = 100
mask = 00000000000000000000000000000000X0XX
mem[26] = 1";
    }
}
