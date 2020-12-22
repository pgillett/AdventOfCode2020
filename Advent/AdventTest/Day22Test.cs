using Advent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace AdventTest
{
    [TestClass]
    public class Day22Test
    {
        private Day22 _day22;

        [TestInitialize]
        public void Setup()
        {
            _day22 = new Day22();
        }

        [TestMethod]
        public void WinningPlayerScoreIs306()
        {
            var expected = 306;

            var actual = _day22.WinningScore(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void WinningPlayerRecursiveScoreIs291()
        {
            var expected = 291;

            var actual = _day22.RecursiveWinningScore(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"Player 1:
9
2
6
3
1

Player 2:
5
8
4
7
10";
    }
}
