using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day12Test
    {
        private Day12 _day12;

        [TestInitialize]
        public void Setup()
        {
            _day12 = new Day12();
        }

        [TestMethod]
        public void SampleManhattanDistanceIs25()
        {
            var expected = 25;

            var actual = _day12.Manhattan(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleManhattanDistanceWithWaypointIs286()
        {
            var expected = 286;

            var actual = _day12.ManhattanWaypoint(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("L0", 10, 5)]
        [DataRow("L90", -5, 10)]
        [DataRow("L180", -10, -5)]
        [DataRow("L270", 5, -10)]
        [DataRow("R0", 10, 5)]
        [DataRow("R90", 5, -10)]
        [DataRow("R180", -10, -5)]
        [DataRow("R270", -5, 10)]
        public void RotatesAreCorrect(string full, int expectedX, int expectedY)
        {
            var waypoint = new Day12.Waypoint(10, 5);
            var instruction = new Day12.Instruction(full);

            var actualWaypoint = waypoint.Move(instruction);

            actualWaypoint.X.Should().Be(expectedX);
            actualWaypoint.Y.Should().Be(expectedY);
        }

        private string _input = @"F10
N3
F7
R90
F11";
    }
}
