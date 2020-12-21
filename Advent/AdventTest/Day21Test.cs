using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day21Test
    {
        private Day21 _day21;

        [TestInitialize]
        public void Setup()
        {
            _day21 = new Day21();
        }

        [TestMethod]
        public void Test()
        {
            var expected = 5;

            var actual = _day21.CountNonAllergens(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Test2()
        {
            var expected = "mxmxvkd,sqjhc,fvjkl";

            var actual = _day21.Dangerous(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"mxmxvkd kfcds sqjhc nhms (contains dairy, fish)
trh fvjkl sbzzf mxmxvkd (contains dairy)
sqjhc fvjkl (contains soy)
sqjhc mxmxvkd sbzzf (contains fish)";
    }
}
