using System;
using System.Collections.Generic;
using System.Text;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day13Test
    {
        private Day13 _day13;

        [TestInitialize]
        public void Setup()
        {
            _day13 = new Day13();
        }

        [TestMethod]
        public void SampleEarliestTimeResultIs295()
        {
            var expected = 295;

            var actual = _day13.FindEarliest(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SequentialTimeStampIs1068781()
        {
            var expected = 1068781;

            var actual = _day13.FindSequential(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"939
7,13,x,x,59,x,31,19";
    }
}
