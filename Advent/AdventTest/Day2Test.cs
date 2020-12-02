using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day2Test
    {
        private Day2 _day2;

        [TestInitialize]
        public void Setup()
        {
            _day2 = new Day2();
        }

        [TestMethod]
        public void NumberOfValidPasswordsByNumber()
        {
            var expectedNumber = 2;

            var actualNumber = _day2.CountCorrectPasswordsNumber(_input);

            actualNumber.Should().Be(expectedNumber);
        }

        [TestMethod]
        public void NumberOfValidPasswordsByPosition()
        {
            var expectedNumber = 1;

            var actualNumber = _day2.CountCorrectPasswordsPosition(_input);

            actualNumber.Should().Be(expectedNumber);
        }

        [TestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", true)]
        public void IsValidNumberShouldCheckNumberOfCharacters(string passwordSet, bool expected)
        {
            var actual = _day2.IsValidNumber(passwordSet);

            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("1-3 a: abcde", true)]
        [DataRow("1-3 b: cdefg", false)]
        [DataRow("2-9 c: ccccccccc", false)]
        public void IsValidPositionShouldCheckNumberOfCharacters(string passwordSet, bool expected)
        {
            var actual = _day2.IsValidPosition(passwordSet);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SplitPasswordReturnsTheCorrectParts()
        {
            var expectedValue1 = 1;
            var expectedValue2 = 2;
            var expectedCharacter = 'a';
            var expectedPassword = "bcd";

            _day2.SplitPassword("1-2 a: bcd",
                out var actualValue1, out var actualValue2,
                out var actualCharacter, out var actualPassword);

            actualValue1.Should().Be(expectedValue1);
            actualValue2.Should().Be(expectedValue2);
            actualCharacter.Should().Be(expectedCharacter);
            actualPassword.Should().Be(expectedPassword);
        }

        private string _input = @"1-3 a: abcde
1-3 b: cdefg
2-9 c: ccccccccc";
    }
}
