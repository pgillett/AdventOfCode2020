using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
[TestClass]
    public class Day03Test
    {
        private Day03 _day03;

        [TestInitialize]
        public void Setup()
        {
            _day03 = new Day03();
        }

        [TestMethod]
        public void CountTreesOnRight3Down1()
        {
            var expected = 7;

            var actual = _day03.CountRight3Down1(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void CountTreesOnMultiplePaths()
        {
            var expected = 336;

            var actual = _day03.CountMultiples(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(1, 4, true)]
        [DataRow(4, 1, true)]
        [DataRow(1, 11, true)]
        [DataRow(5, 0, false)]
        [DataRow(1, 12, false)]
        public void IsTreeAtReturnsCorrectValue(int row, int col, bool expected)
        {
            var actual = _day03.IsTreeAt(_input.Split(Environment.NewLine), row, col);

            actual.Should().Be(expected);
        }

        private string _input = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";
    }
}