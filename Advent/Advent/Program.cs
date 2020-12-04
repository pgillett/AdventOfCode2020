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
                var results2 = day1.ExpenseTwoResult(InputData.Day1Expenses);
                Console.WriteLine($"Two values: {results2}");
                var results3 = day1.ExpenseThreeResult(InputData.Day1Expenses);
                Console.WriteLine($"Three values: {results3}");
            }

            {
                var day2 = new Day2();
                WriteDay(2);
                var resultsNumber = day2.CountCorrectPasswordsNumber(InputData.Day2Passwords);
                Console.WriteLine($"By number: {resultsNumber}");
                var resultsPosition = day2.CountCorrectPasswordsPosition(InputData.Day2Passwords);
                Console.WriteLine($"By position: {resultsPosition}");
            }

            {
                var day3 = new Day3();
                WriteDay(3);
                var resultsRight3Down1 = day3.CountRight3Down1(InputData.Day3Trees);
                Console.WriteLine($"Right 3 down 1: {resultsRight3Down1}");
                var resultsMultiples = day3.CountMultiples(InputData.Day3Trees);
                Console.WriteLine($"Multiple paths: {resultsMultiples}");
            }

            {
                var day4 = new Day4();
                WriteDay(4);
                var numberOfBasicPassports = day4.CountBasicValidPassports(InputData.Day4Passport);
                Console.WriteLine($"Basic valid passports: {numberOfBasicPassports}");
                var numberOfFullyValidatedPassports = day4.CountFullyValidatedPassports(InputData.Day4Passport);
                Console.WriteLine($"Fully validated: {numberOfFullyValidatedPassports}");
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
