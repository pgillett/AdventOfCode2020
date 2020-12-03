using System;
using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
[TestClass]
    public class Day3Test
    {
        private Day3 _day3;

        [TestInitialize]
        public void Setup()
        {
            _day3 = new Day3();
        }

        [TestMethod]
        public void CountTreesOnRight3Down1()
        {
            var expected = 7;

            var actual = _day3.CountRight3Down1(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void CountTreesOnMultiplePaths()
        {
            var expected = 336;

            var actual = _day3.CountMultiples(_input);

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
            var actual = _day3.IsTreeAt(_input.Split(Environment.NewLine), row, col);

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