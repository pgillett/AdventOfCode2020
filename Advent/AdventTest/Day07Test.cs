using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day07Test
    {
        private Day07 _day07;

        [TestInitialize]
        public void Setup()
        {
            _day07 = new Day07();
        }

        [TestMethod]
        public void SampleInputRulesShouldBeFourBags()
        {
            var expected = 4;

            var actual = _day07.CountOuterBagsForShinyGold(_input1);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleInputRulesShouldTotal126Bags()
        {
            var expected = 126;

            var actual = _day07.TotalNumberOfBags(_input2);

            actual.Should().Be(expected);
        }

        private string _input1 = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

        private string _input2 = @"shiny gold bags contain 2 dark red bags.
dark red bags contain 2 dark orange bags.
dark orange bags contain 2 dark yellow bags.
dark yellow bags contain 2 dark green bags.
dark green bags contain 2 dark blue bags.
dark blue bags contain 2 dark violet bags.
dark violet bags contain no other bags.";
    }
}
