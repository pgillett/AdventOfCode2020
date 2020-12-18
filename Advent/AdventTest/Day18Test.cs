using System;
using System.Collections.Generic;
using System.Text;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day18Test
    {
        private Day18 _day18;

        [TestInitialize]
        public void Setup()
        {
            _day18 = new Day18();
        }

        [TestMethod]
        [DataRow("(1 + 2) * 2", 6)]
        [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [DataRow("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [DataRow("2 * 3 + (4 * 5)", 26)]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void CalculationsWithoutPrecedence(string input, int expected)
        {
            var actual = _day18.Calculate(input, false);

            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("(1 + 2) + 2 * 1", 5)]
        [DataRow("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [DataRow("2 * 3 + (4 * 5)", 46)]
        [DataRow("5 + (8 * 3 + 9 + 3 * 4 * 3)", 1445)]
        [DataRow("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 669060)]
        [DataRow("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 23340)]
        public void CalculationsWithAddPrecendence(string input, int expected)
        {
            var actual = _day18.Calculate(input, true);

            actual.Should().Be(expected);
        }

        private string _input = @"";
    }
}
