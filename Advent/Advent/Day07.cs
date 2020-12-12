using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day07
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

        private Dictionary<string, List<(string name, int count)>> ParseData(string input) =>
            input
                .Split(Environment.NewLine)
                .Select(line => line.Split(" bags contain "))
                .Select(pair => (name: pair[0], contents: GetContents(pair[1])))
                .ToDictionary(bag => bag.name, 
                    r => r.contents);

        private List<(string name, int count)> GetContents(string contents) =>
            contents
                .Split(',')
                .Where(s => !s.Contains("no other"))
                .Select(contains => contains.Replace(".", "")
                    .Replace("bags", "")
                    .Replace("bag", "")
                    .Trim()
                    .Split(' ', 2))
                .Select(cleaned => (name: cleaned[1], count: int.Parse(cleaned[0])))
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
