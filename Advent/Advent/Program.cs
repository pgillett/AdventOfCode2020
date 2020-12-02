using System;

namespace Advent
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var day1 = new Day1();
                WriteDay(1);
                var results2 = day1.FindExpenseTwo(InputData.Day1Expenses);
                Console.WriteLine($"Two values: {results2.Item1 * results2.Item2}");
                var results3 = day1.FindExpenseThree(InputData.Day1Expenses);
                Console.WriteLine($"Three values: {results3.Item1 * results3.Item2 * results3.Item3}");
            }

            {
                var day2 = new Day2();
                WriteDay(2);
                var resultsNumber = day2.CountCorrectPasswordsNumber(InputData.Day2Passwords);
                Console.WriteLine($"By number: {resultsNumber}");
                var resultsPosition = day2.CountCorrectPasswordsPosition(InputData.Day2Passwords);
                Console.WriteLine($"By position: {resultsPosition}");
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
