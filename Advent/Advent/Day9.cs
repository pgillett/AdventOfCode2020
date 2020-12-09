using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day9
    {
        public long FailingNumber(string input, int preamble)
        {
            var numbers = ParseData(input);

            for (var start = preamble; start < numbers.Length; start++)
            {
                var foundPair = false;

                for (var first = start - preamble; first < start - 1 && !foundPair; first++)
                {
                    for (var second = first + 1; second < start && !foundPair; second++)
                    {
                        foundPair = numbers[first] + numbers[second] == numbers[start];
                    }
                }

                if (foundPair == false) return numbers[start];
            }

            return -1;
        }

        public long TotalOfRun(string input, long target)
        {
            var numbers = ParseData(input);

            for (var start = 0; start < numbers.Length - 1; start++)
            {
                var set = new List<long>();
                for (var run = start; start < numbers.Length && set.Sum() < target; run++)
                {
                    set.Add(numbers[run]);
                    if (set.Sum() == target && set.Count > 1)
                    {
                        return set.Min() + set.Max();
                    }
                }
            }

            return -1;
        }

        private long[] ParseData(string input) => input
            .Split(Environment.NewLine)
            .Select(long.Parse)
            .ToArray();
    }
}
