using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day19
    {
        public int ValidMessages(string input)
        {
            var rules = Decode(input, out var dataLines);

            return CountValid(dataLines, rules);
        }

        public int ValidMessagesWithSwitch(string input)
        {
            var rules = Decode(input, out var dataLines);

            rules[8] = new Rule("8: 42 | 42 8");
            rules[11] = new Rule("11: 42 31 | 42 11 31");

            return CountValid(dataLines, rules);
        }

        private Dictionary<int, Rule> Decode(string input, out string[] dataLines)
        {
            var split = input.Split(Environment.NewLine + Environment.NewLine);

            var rules = split[0]
                .Split(Environment.NewLine)
                .Select(r => new Rule(r))
                .ToDictionary(r => r.Number, r => r);

            dataLines = split[1].Split(Environment.NewLine);
            return rules;
        }
        
        private int CountValid(string[] dataLines, Dictionary<int, Rule> rules) =>
            dataLines
                .Count(data =>
                    Process(data, 0, rules, 0)
                        .Any(m => m == data));


        private List<string> Process(string data, int pos, Dictionary<int, Rule> rules, int ruleNumber)
        {
            var comboSet = new List<string>();
            var rule = rules[ruleNumber];
            if (rule.IsLetter)
            {
                if (pos<data.Length && data[pos] == rule.MatchLetter)
                    comboSet.Add(data.Substring(pos, 1));
            }
            else
            {
                foreach (var rulePair in rule.InnerRule)
                {
                    var section = data.Substring(pos);
                    var currentCombos = new List<string> {""};

                    foreach (var inner in rulePair)
                    {
                        var newResult = new List<string>();

                        foreach (var first in currentCombos)
                        {
                            newResult.AddRange(
                                Process(data, pos + first.Length, rules, inner)
                                    .Select(second => first + second)
                                    .Where(result => section.StartsWith(result)));
                        }

                        currentCombos = newResult;
                    }

                    comboSet.AddRange(currentCombos);
                }
            }

            return comboSet;
        }

        private class Rule
        {
            public readonly int Number;
            public readonly bool IsLetter;
            public readonly char MatchLetter;

            public readonly int[][] InnerRule;

            public Rule(string data)
            {
                var split = data.Split(": ");
                Number = int.Parse(split[0]);

                if (split[1][0] == '\"')
                {
                    IsLetter = true;
                    MatchLetter = split[1][1];
                }
                else
                {
                    var splitOrs = split[1].Split(" | ");
                    InnerRule = splitOrs
                        .Select(p => p.Split(' ')
                            .Select(int.Parse)
                            .ToArray())
                        .ToArray();
                }
            }
        }
    }
}
