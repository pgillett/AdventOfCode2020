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
                var day6=new Day06();
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
                var day12= new Day12();
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
        }

        static void WriteDay(int day)
        {
            Console.WriteLine();
            Console.WriteLine($"DAY {day}");
            Console.WriteLine($"==========");
        }
    }
}
