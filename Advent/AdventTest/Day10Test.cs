using Advent;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace AdventTest
{
    [TestClass]
    public class Day10Test
    {
        private Day10 _day10;

        [TestInitialize]
        public void Setup()
        {
            _day10=new Day10();
        }

        [TestMethod]
        public void NumberOfJoltDifferencesIs22and10()
        {
            var expected1 = 22;
            var expected3 = 10;

            var actual = _day10.JoltDifference(_input);

            actual.jolt1.Should().Be(expected1);
            actual.jolt3.Should().Be(expected3);
        }

        [TestMethod]
        public void CombinationsShouldBe19208()
        {
            var expected = 19208;
            var actual = _day10.Combinations(_input);
            actual.Should().Be((expected));
        }

        private string _input = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
    }
}
