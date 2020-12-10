using System;
using System.Linq;

namespace Advent
{
    public class Day10
    {
        public (int jolt1, int jolt3) JoltDifference(string input)
        {
            var sorted = GetAdapters(input);

            var jolts = new int[4];

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                jolts[sorted[i + 1] - sorted[i]]++;
            }

            return (jolts[1], jolts[3]);
        }

        private static int[] GetAdapters(string input)
        {
            var adapters = input
                .Split(Environment.NewLine)
                .Select(int.Parse)
                .ToList();

            adapters.AddRange(new[] {0, adapters.Max() + 3});

            return adapters
                .OrderBy(a => a)
                .ToArray();
        }

        public int JoltProduct(string input)
        {
            var res = JoltDifference(input);
            return res.jolt1 * res.jolt3;
        }

        public long Combinations(string input)
        {
            var sorted = GetAdapters(input);

            var combinations = new long[sorted.Length];
            combinations[sorted.Length - 1] = 1;

            for (var first = sorted.Length - 2; first >= 0; first--)
            {
                for (var second = first + 1; 
                    second < sorted.Length && sorted[second] - sorted[first] <= 3; 
                    second++)
                {
                    combinations[first] += combinations[second];
                }
            }

            return combinations[0];
        }
    }
}
