using System;
using System.Linq;

namespace Advent
{
    public class Day01
    {
        public int ExpenseTwoResult(string allExpenses)
        {
            var results = FindExpenseTwo(allExpenses);
            return results.Item1 * results.Item2;
        }

        public int ExpenseThreeResult(string allExpenses)
        {
            var results = FindExpenseThree(allExpenses);
            return results.Item1 * results.Item2 * results.Item3;
        }

        public (int, int) FindExpenseTwo(string allExpenses)
        {
            var expenses = allExpenses
                .Split(Environment.NewLine)
                .Select(s => int.Parse(s))
                .ToList();

            for(int first = 0; first <expenses.Count -1 ;first++)
            {
                for(int second = first+1; second<expenses.Count ;second++)
                {
                    if (expenses[first] + expenses[second] == 2020) return (expenses[first], expenses[second]);
                }
            }

            throw new Exception("Not found");
        }

        public (int, int, int) FindExpenseThree(string allExpenses)
        {
            var expenses = allExpenses
                .Split(Environment.NewLine)
                .Select(s => int.Parse(s))
                .ToList();

            for (int first = 0; first < expenses.Count - 2; first++)
            {
                for (int second = first + 1; second < expenses.Count-1; second++)
                {
                    for (int third = second + 1; third < expenses.Count; third++)
                    {
                        if (expenses[first] + expenses[second] + expenses[third] == 2020)
                            return (expenses[first], expenses[second], expenses[third]);
                    }
                }
            }

            throw new Exception("Not found");
        }
    }
}
