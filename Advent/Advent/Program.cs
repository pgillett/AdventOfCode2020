using System;
using System.Diagnostics;

namespace Advent
{
    class Program
    {
        private static Stopwatch _stopwatch;

        private const int From = 1;
        private const int To = 25;

        private static readonly int[,] Times = new int[25, 2];

        static void Main(string[] args)
        {
            _stopwatch = new Stopwatch();

            if (IncludeDay(1))
            {
                var day1 = new Day01();
                Output(1,1,"Two values", day1.ExpenseTwoResult(InputData.Day01Expenses));
                Output(1,2,"Three values", day1.ExpenseThreeResult(InputData.Day01Expenses));
            }

            if (IncludeDay(2))
            {
                var day2 = new Day02();
                Output(2,2,"By number", day2.CountCorrectPasswordsNumber(InputData.Day02Passwords));
                Output(2,2,"By position", day2.CountCorrectPasswordsPosition(InputData.Day02Passwords));
            }

            if (IncludeDay(3))
            {
                var day3 = new Day03();
                Output(3,1,"Right 3 down 1", day3.CountRight3Down1(InputData.Day03Trees));
                Output(3,2,"Multiple paths", day3.CountMultiples(InputData.Day03Trees));
            }

            if (IncludeDay(4))
            {
                var day4 = new Day04();
                Output(4,1,"Basic valid passports", day4.CountBasicValidPassports(InputData.Day04Passport));
                Output(4,2,"Fully validated", day4.CountFullyValidatedPassports(InputData.Day04Passport));
            }

            if (IncludeDay(5))
            {
                var day5 = new Day05();
                Output(5,1,"Highest seat ID", day5.HighestSeatId(InputData.Day05Boarding));
                Output(5,2,"My seat ID", day5.FindSeatId(InputData.Day05Boarding));
            }

            if (IncludeDay(6))
            {
                var day6 = new Day06();
                Output(6,1,"Number of questions", day6.CountGroupQuestions(InputData.Day06Customs));
                Output(6,2,"Matching questions in group", day6.CountMatchingInGroupQuestions(InputData.Day06Customs));
            }

            if (IncludeDay(7))
            {
                var day7 = new Day07();
                Output(7,1,"Number of bags", day7.CountOuterBagsForShinyGold(InputData.Day07Haversacks));
                Output(7,2,"Total bags", day7.TotalNumberOfBags(InputData.Day07Haversacks));
            }

            if (IncludeDay(8))
            {
                var day8 = new Day08();
                Output(8,1,"Accumulator at crash", day8.AccumulateAtCrash(InputData.Day08Handheld));
                Output(8,2,"Accumulator with fix", day8.FixAndAccumulator(InputData.Day08Handheld));
            }

            if (IncludeDay(9))
            {
                var day9 = new Day09();
                var failingNumber = day9.FailingNumber(InputData.Day09Encoding, 25);
                Output(9,1,"Failing number", failingNumber);
                Output(9,2,"Total of run", day9.TotalOfRun(InputData.Day09Encoding, failingNumber));
            }

            if (IncludeDay(10))
            {
                var day10 = new Day10();
                Output(10,1,"Jolt product", day10.JoltProduct(InputData.Day10Adapter));
                Output(10,2,"Combinations", day10.Combinations(InputData.Day10Adapter));
            }

            if (IncludeDay(11))
            {
                var day11 = new Day11();
                Output(11,1,"Occupied near", day11.SeatsAtEquilibriumNear(InputData.Day11Seating));
                Output(11,2,"Occupied distance", day11.SeatsAtEquilibriumFurther(InputData.Day11Seating));
            }

            if (IncludeDay(12))
            {
                var day12 = new Day12();
                Output(12,1,"Distance", day12.Manhattan(InputData.Day12Rain));
                Output(12,2,"Distance waypoint", day12.ManhattanWaypoint(InputData.Day12Rain));
            }

            if (IncludeDay(13))
            {
                var day13 = new Day13();
                Output(13,1,"Earliest depart", day13.FindEarliest(InputData.Day13Shuttle));
                Output(13,2,"Sequential depart", day13.FindSequential(InputData.Day13Shuttle));
            }

            if (IncludeDay(14))
            {
                var day14 = new Day14();
                Output(14,1,"Sum of memory", day14.SumOfMemory(InputData.Day14Docking));
                Output(14,2,"Sum of floating", day14.SumOfFloatingMemory(InputData.Day14Docking));
            }

            {
                var day15 = new Day15();
                IncludeDay(15);
                Output(15,1,"2020th number", day15.Find(2020, InputData.Day15NumberGame));
                Output(15,2,"30m th number", day15.Find(30000000, InputData.Day15NumberGame));
            }

            if (IncludeDay(16))
            {
                var day16 = new Day16();
                Output(16,1,"Error rate", day16.InvalidErrorRate(InputData.Day16Ticket));
                Output(16,2,"Departure product", day16.DepartureProduct(InputData.Day16Ticket));
            }

            if (IncludeDay(17))
            {
                var day17 = new Day17();
                Output(17,1,"Active in 3d", day17.Active(3, InputData.Day17Cubes));
                Output(17,2,"Active in 4d", day17.Active(4, InputData.Day17Cubes));
            }

            if (IncludeDay(18))
            {
                var day18 = new Day18();
                Output(18,1,"Active in 3d", day18.SumOfWithNoPrecedence(InputData.Day18Order));
                Output(18,2,"Active in 4d", day18.SumOfAddTakesPrecedence(InputData.Day18Order));
            }

            if (IncludeDay(19))
            {
                var day19 = new Day19();
                Output(19,1,"Valid messages", day19.ValidMessages(InputData.Day19Messages));
                Output(19,2,"Valid messages with switch", day19.ValidMessagesWithSwitch(InputData.Day19Messages));
            }

            if (IncludeDay(20))
            {
                var day20 = new Day20();
                Output(20,1,"Corners multiplied", day20.CornerMultiply(InputData.Day20Jigsaw));
                Output(20,2,"Roughness", day20.SeaMonsters(InputData.Day20Jigsaw));
            }

            if (IncludeDay(21))
            {
                var day21 = new Day21();
                Output(21,1,"Non allergens", day21.CountNonAllergens(InputData.Day21Allergen));
                Output(21,2,"Dangerous", day21.Dangerous(InputData.Day21Allergen));
            }

            if (IncludeDay(22))
            {
                var day22 = new Day22();
                Output(22,1,"Winning score", day22.WinningScore(InputData.Day22Crab));
                Output(22,2,"Recursive winning score", day22.RecursiveWinningScore(InputData.Day22Crab));
            }

            if (IncludeDay(23))
            {
                var day23 = new Day23();
                Output(23,1,"Cups from 1", day23.TextFrom1(InputData.Day23Cups, 100));
                Output(23,2,"Multiply right 2", day23.RightMultiply(InputData.Day23Cups, 10000000));
            }

            if (IncludeDay(24))
            {
                var day24 = new Day24();
                Output(24,1,"Black tiles", day24.CountBlack(InputData.Day24Hex));
                Output(24,2,"Black after 100 days", day24.CountBlack100Days(InputData.Day24Hex));
            }

            if (IncludeDay(25))
            {
                var day25 = new Day25();
                Output(25,1,"Encryption key", day25.EncryptionKey(InputData.Day25Keys));
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Day       Part 1    Part 2");
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine($"{i+1,-10}{Times[i,0],5} ms  {Times[i,1],5} ms");
            }
        }

        static bool IncludeDay(int day)
        {
            if (day < From || day > To) return false;

            _stopwatch.Reset();
            _stopwatch.Start();
            Console.WriteLine();
            Console.WriteLine($"DAY {day}");
            Console.WriteLine($"==========");

            return true;
        }

        static void Output(int day, int part, string name, object answer)
        {
            var time = _stopwatch.ElapsedMilliseconds;
            Times[day-1, part-1] = (int)time;
            Console.WriteLine($"{time} ms - {name}: {answer}");
            _stopwatch.Reset();
            _stopwatch.Start();
        }
    }
}
