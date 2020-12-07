using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day7
    {
        public int CountOuterBagsForShinyGold(string input)
        {
            var bags = ParseData(input);

            return bags.Keys.Count(bag => CheckBag(bags, bag));
        }

        private bool CheckBag(Dictionary<string, List<(string name, int count)>> bags, string bag) => 
            bags.ContainsKey(bag)
            && bags[bag].Any(inner => 
                inner.name == ShinyGold || CheckBag(bags, inner.name));

        private Dictionary<string, List<(string, int)>> ParseData(string input)
        {
            var rules = input.Split(Environment.NewLine);

            return rules.Select(r =>
            {
                var s = r.Split(" bags contain ");
                return (s[0], GetContents(s[1]));
            })
                .ToDictionary(r => r.Item1, 
                    r => r.Item2);
        }

        private List<(string, int)> GetContents(string contents) =>
            contents
                .Split(',')
                .Where(s => !s.Contains("no other"))
                .Select(contains => contains.Replace(".", "")
                    .Replace("bags", "")
                    .Replace("bag", "")
                    .Trim()
                    .Split(' ', 2))
                .Select(cleaned => (cleaned[1], int.Parse(cleaned[0])))
                .ToList();

        public int TotalNumberOfBags(string input)
        {
            var bags = ParseData(input);

            return CountBags(bags, ShinyGold);
        }

        private int CountBags(Dictionary<string, List<(string name, int count)>> bags, string bag) =>
            !bags.ContainsKey(bag)
                ? 1
                : bags[bag]
                    .Sum(inner =>
                        inner.count * (1 + CountBags(bags, inner.name)));

        private const string ShinyGold = "shiny gold";
    }
}
