using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day05Test
    {
        private Day05 _day05;

        [TestInitialize]
        public void Setup()
        {
            _day05 = new Day05();
        }

        [TestMethod]
        [DataRow("BFFFBBFRRR", 70, 7, 567)]
        [DataRow("FFFBBBFRRR", 14, 7, 119)]
        [DataRow("BBFFBBFRLL", 102, 4, 820)]
        public void DecodeReturnsCorrectRowColumnId(string board, int expectedRow, int expectedCol, int expectedId)
        {
            var result = _day05.Decode(board);

            var actualRow = result.row;
            var actualCol = result.column;
            var actualId = result.id;

            actualRow.Should().Be(expectedRow);
            actualCol.Should().Be(expectedCol);
            actualId.Should().Be(expectedId);
        }

        [TestMethod]
        public void CheckHighestSeatId()
        {
            var expectedId = 820;

            var actualId = _day05.HighestSeatId(_input);

            actualId.Should().Be(expectedId);
        }

        private string _input = @"BFFFBBFRRR
FFFBBBFRRR
BBFFBBFRLL";
    }
}
