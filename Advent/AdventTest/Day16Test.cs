using System;
using System.Collections.Generic;
using System.Text;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day16Test
    {
        public Day16 _day16;

        [TestInitialize]
        public void Setup()
        {
            _day16 = new Day16();
        }

        [TestMethod]
        public void SampleInputHas71Invalid()
        {
            var expected = 71;

            var actual = _day16.InvalidErrorRate(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleInputHasDepartureProduct14()
        {
            var expected = 14;

            var actual = _day16.DepartureProduct(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"class: 1-3 or 5-7
row: 6-11 or 33-44
departure: 13-40 or 45-50

your ticket:
7,1,14

nearby tickets:
7,3,47
40,4,50
55,2,20
38,6,12";
    }
}
