using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day15Test
    {
        private Day15 _day15;

        [TestInitialize]
        public void Setup()
        {
            _day15=new Day15();
        }

        [TestMethod]
        [DataRow("0,3,6",436)]
        [DataRow("1,3,2", 1)]
        [DataRow("2,1,3", 10)]
        [DataRow("1,2,3", 27)]
        [DataRow("2,3,1", 78)]
        [DataRow("3,2,1", 438)]
        [DataRow("3,1,2", 1836)]
        public void The2020thNumberIs(string input, int expected)
        {
            var actual = _day15.Find(2020, input);

            actual.Should().Be(expected);
        }

        
    }
}
