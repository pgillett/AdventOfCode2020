using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day06Test
    {
        private Day06 _day06;

        [TestInitialize]
        public void Setup()
        {
            _day06 = new Day06();
        }

        [TestMethod]
        public void SampleDataHasElevenQuestions()
        {
            var expected = 11;

            var actual = _day06.CountGroupQuestions(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleDataHasSixQuestionsThatAllPeopleInGroupAnswer()
        {
            var expected = 6;

            var actual = _day06.CountMatchingInGroupQuestions(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
    }
}
