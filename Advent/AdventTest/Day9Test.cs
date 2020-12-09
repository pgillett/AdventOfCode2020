using Advent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace AdventTest
{
    [TestClass]
    public class Day9Test
    {
        private Day9 _day9;

        [TestInitialize]
        public void Setup()
        {
            _day9=new Day9();
        }

        [TestMethod]
        public void FailingNumberInSamplePreambleFiveIs127()
        {
            var expected = 127;

            var actual = _day9.FailingNumber(_input, 5);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void TotalOfContinuousRunInSampleIs62()
        {
            var expected = 62;

            var actual = _day9.TotalOfRun(_input, 127);

            actual.Should().Be(expected);
        }

        private string _input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
    }
}
