using System;

namespace Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var day1 = new Day01();
                WriteDay(1);
                var results2 = day1.ExpenseTwoResult(InputData.Day01Expenses);
                Console.WriteLine($"Two values: {results2}");
                var results3 = day1.ExpenseThreeResult(InputData.Day01Expenses);
                Console.WriteLine($"Three values: {results3}");
            }

            {
                var day2 = new Day02();
                WriteDay(2);
                var resultsNumber = day2.CountCorrectPasswordsNumber(InputData.Day02Passwords);
                Console.WriteLine($"By number: {resultsNumber}");
                var resultsPosition = day2.CountCorrectPasswordsPosition(InputData.Day02Passwords);
                Console.WriteLine($"By position: {resultsPosition}");
            }

            {
                var day3 = new Day03();
                WriteDay(3);
                var resultsRight3Down1 = day3.CountRight3Down1(InputData.Day03Trees);
                Console.WriteLine($"Right 3 down 1: {resultsRight3Down1}");
                var resultsMultiples = day3.CountMultiples(InputData.Day03Trees);
                Console.WriteLine($"Multiple paths: {resultsMultiples}");
            }

            {
                var day4 = new Day04();
                WriteDay(4);
                var numberOfBasicPassports = day4.CountBasicValidPassports(InputData.Day04Passport);
                Console.WriteLine($"Basic valid passports: {numberOfBasicPassports}");
                var numberOfFullyValidatedPassports = day4.CountFullyValidatedPassports(InputData.Day04Passport);
                Console.WriteLine($"Fully validated: {numberOfFullyValidatedPassports}");
            }

            {
                var day5 = new Day05();
                WriteDay(5);
                var highestSeatId = day5.HighestSeatId(InputData.Day05Boarding);
                Console.WriteLine($"Highest seat ID {highestSeatId}");
                var findSeatId = day5.FindSeatId(InputData.Day05Boarding);
                Console.WriteLine($"My seat ID: {findSeatId}");
            }

            {
                var day6 = new Day06();
                WriteDay(6);
                var countQuestions = day6.CountGroupQuestions(InputData.Day06Customs);
                Console.WriteLine($"Number of questions: {countQuestions}");
                var countMatchQuestions = day6.CountMatchingInGroupQuestions(InputData.Day06Customs);
                Console.WriteLine($"Matching questions in group: {countMatchQuestions}");
            }

            {
                var day7 = new Day07();
                WriteDay(7);
                var outerBags = day7.CountOuterBagsForShinyGold(InputData.Day07Haversacks);
                Console.WriteLine($"Number of bags: {outerBags}");
                var totalBags = day7.TotalNumberOfBags(InputData.Day07Haversacks);
                Console.WriteLine($"Total bags: {totalBags}");
            }

            {
                var day8 = new Day08();
                WriteDay(8);
                var accumulatorAtCrash = day8.AccumulateAtCrash(InputData.Day08Handheld);
                Console.WriteLine($"Accumulator at crash: {accumulatorAtCrash}");
                var accumulatorWithFix = day8.FixAndAccumulator(InputData.Day08Handheld);
                Console.WriteLine($"Accumulator with fix: {accumulatorWithFix}");
            }

            {
                var day9 = new Day09();
                WriteDay(9);
                var failingNumber = day9.FailingNumber(InputData.Day09Encoding, 25);
                Console.WriteLine($"Failing number: {failingNumber}");
                var totalOfRun = day9.TotalOfRun(InputData.Day09Encoding, failingNumber);
                Console.WriteLine($"Total of run: {totalOfRun}");
            }

            {
                var day10 = new Day10();
                WriteDay(10);
                var joltProduct = day10.JoltProduct(InputData.Day10Adapter);
                Console.WriteLine($"Jolt product: {joltProduct}");
                var combinations = day10.Combinations(InputData.Day10Adapter);
                Console.WriteLine($"Combinations: {combinations}");
            }

            {
                var day11 = new Day11();
                WriteDay(11);
                var occupied = day11.SeatsAtEquilibriumNear(InputData.Day11Seating);
                Console.WriteLine($"Occupied near: {occupied}");
                var occupiedDistance = day11.SeatsAtEquilibriumFurther(InputData.Day11Seating);
                Console.WriteLine($"Occupied distance: {occupiedDistance}");
            }

            {
                var day12 = new Day12();
                WriteDay(12);
                var distance = day12.Manhattan(InputData.Day12Rain);
                Console.WriteLine($"Distance: {distance}");
                var distanceWayPoint = day12.ManhattanWaypoint(InputData.Day12Rain);
                Console.WriteLine($"Distance waypoint: {distanceWayPoint}");
            }

            {
                var day13 = new Day13();
                WriteDay(13);
                var earliestDepart = day13.FindEarliest(InputData.Day13Shuttle);
                Console.WriteLine($"Earliest depart: {earliestDepart}");
                var sequentialDepart = day13.FindSequential(InputData.Day13Shuttle);
                Console.WriteLine($"Sequential depart: {sequentialDepart}");
            }

            {
                var day14 = new Day14();
                WriteDay(14);
                var sumOfMemory = day14.SumOfMemory(InputData.Day14Docking);
                Console.WriteLine($"Sum of memory: {sumOfMemory}");
                var sumOfFloatingMemory = day14.SumOfFloatingMemory(InputData.Day14Docking);
                Console.WriteLine($"Sum of floating: {sumOfFloatingMemory}");
            }

            {
                var day15 = new Day15();
                WriteDay(15);
                var number2020 = day15.Find(2020, InputData.Day15NumberGame);
                Console.WriteLine($"2020th number: {number2020}");
                var number30million = day15.Find(30000000, InputData.Day15NumberGame);
                Console.WriteLine($"30m th number: {number30million}");
            }

            {
                var day16 = new Day16();
                WriteDay(16);
                var errorRate = day16.InvalidErrorRate(InputData.Day16Ticket);
                Console.WriteLine($"Error rate: {errorRate}");
                var departureProduct = day16.DepartureProduct(InputData.Day16Ticket);
                Console.WriteLine($"Departure product: {departureProduct}");
            }

            {
                var day17 = new Day17();
                WriteDay(17);
                var active3 = day17.Active(3, InputData.Day17Cubes);
                Console.WriteLine($"Active in 3d: {active3}");
                var active4 = day17.Active(4, InputData.Day17Cubes);
                Console.WriteLine($"Active in 4d: {active4}");
            }

            {
                var day18 = new Day18();
                WriteDay(18);
                var sumOfEquations1 = day18.SumOfWithNoPrecedence(InputData.Day18Order);
                Console.WriteLine($"Active in 3d: {sumOfEquations1}");
                var sumOfEquations2 = day18.SumOfAddTakesPrecedence(InputData.Day18Order);
                Console.WriteLine($"Active in 4d: {sumOfEquations2}");
            }

            {
                var day19 = new Day19();
                WriteDay(19);
                var validMessages = day19.ValidMessages(InputData.Day19Messages);
                Console.WriteLine($"Valid messages: {validMessages}");
                var validMessagesWithSwitch = day19.ValidMessagesWithSwitch(InputData.Day19Messages);
                Console.WriteLine($"Valid messages with switch: {validMessagesWithSwitch}");
            }


            {
                var day20 = new Day20();
                WriteDay(20);
                var cornerMultiply = day20.CornerMultiply(InputData.Day20Jigsaw);
                Console.WriteLine($"Corners multiplied: {cornerMultiply}");
                var roughness = day20.SeaMonsters(InputData.Day20Jigsaw);
                Console.WriteLine($"Roughness: {roughness}");
            }

            {
                var day21 = new Day21();
                WriteDay(21);
                var countNonAllergens = day21.CountNonAllergens(InputData.Day21Allergen);
                Console.WriteLine($"Non allergens: {countNonAllergens}");
                var dangerous = day21.Dangerous(InputData.Day21Allergen);
                Console.WriteLine($"Dangerous: {dangerous}");
            }

            {
                var day22 = new Day22();
                WriteDay(22);
                var winningScore = day22.WinningScore(InputData.Day22Crab);
                Console.WriteLine($"Winning score: {winningScore}");
                var recursiveWinningScore = day22.RecursiveWinningScore(InputData.Day22Crab);
                Console.WriteLine($"Recursive winning score: {recursiveWinningScore}");
            }

            {
                var day23 = new Day23();
                WriteDay(1);
                var textFrom1 = day23.TextFrom1(InputData.Day23Cups, 100);
                Console.WriteLine($"Cups from 1: {textFrom1}");
                var rightMultiply = day23.RightMultiply(InputData.Day23Cups, 10000000);
                Console.WriteLine($"Multiply right 2: {rightMultiply}");
            }
        }

        static void WriteDay(int day)
        {
            Console.WriteLine();
            Console.WriteLine($"DAY {day}");
            Console.WriteLine($"==========");
        }
    }
}
