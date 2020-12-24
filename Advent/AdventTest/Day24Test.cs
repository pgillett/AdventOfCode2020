using Advent;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventTest
{
    [TestClass]
    public class Day24Test
    {
        private Day24 _day24;

        [TestInitialize]
        public void Setup()
        {
            _day24 = new Day24();
        }

        [TestMethod]
        public void SampleHas10Black()
        {
            var expected = 10;

            var actual = _day24.CountBlack(_input);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void SampleHas2208BlackAfter100Days()
        {
            var expected = 2208;

            var actual = _day24.CountBlack100Days(_input);

            actual.Should().Be(expected);
        }

        private string _input = @"sesenwnenenewseeswwswswwnenewsewsw
neeenesenwnwwswnenewnwwsewnenwseswesw
seswneswswsenwwnwse
nwnwneseeswswnenewneswwnewseswneseene
swweswneswnenwsewnwneneseenw
eesenwseswswnenwswnwnwsewwnwsene
sewnenenenesenwsewnenwwwse
wenwwweseeeweswwwnwwe
wsweesenenewnwwnwsenewsenwwsesesenwne
neeswseenwwswnwswswnw
nenwswwsewswnenenewsenwsenwnesesenew
enewnwewneswsewnwswenweswnenwsenwsw
sweneswneswneneenwnewenewwneswswnese
swwesenesewenwneswnwwneseswwne
enesenwswwswneneswsenwnewswseenwsese
wnwnesenesenenwwnenwsewesewsesesew
nenewswnwewswnenesenwnesewesw
eneswnwswnwsenenwnwnwwseeswneewsenese
neswnwewnwnwseenwseesewsenwsweewe
wseweeenwnesenwwwswnew";
    }
}
