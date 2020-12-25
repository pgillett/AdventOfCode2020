using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day25Test
    {
        private Day25 _day25;

        [TestInitialize]
        public void Setup()
        {
            _day25 = new Day25();
        }

        [TestMethod]
        public void SampleEncryptionKeyIs14897079()
        {
            var expected = 14897079;

            var actual = _day25.EncryptionKey(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"5764801
17807724";
    }
}
