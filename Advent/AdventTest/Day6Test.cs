using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day6Test
    {
        private Day6 _day6;

        [TestInitialize]
        public void Setup()
        {
            _day6 = new Day6();
        }

        [TestMethod]
        public void SampleDataHasElevenQuestions()
        {
            var expected = 11;

            var actual = _day6.CountGroupQuestions(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleDataHasSixQuestionsThatAllPeopleInGroupAnswer()
        {
            var expected = 6;

            var actual = _day6.CountMatchingInGroupQuestions(_input);

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
