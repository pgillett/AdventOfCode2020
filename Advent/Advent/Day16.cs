using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Advent
{
    public class Day16
    {
        public int InvalidErrorRate(string input)
        {
            var set = Decode(input);

            return set.nearby
                .Sum(ticket => ticket.SingleOrDefault(v => !AnyValid(v, set.rules)));
        }

        public long DepartureProduct(string input)
        {
            var set = Decode(input);

            var validTickets = set.nearby
                .Where(ticket => ticket.All(value => AnyValid(value, set.rules)))
                .ToArray();

            var noOfRules = set.rules.Length;

            var rulePosition = new List<int>[noOfRules];

            for (var i = 0; i < noOfRules; i++)
                rulePosition[i] = new List<int>();

            var includes = new List<int>[noOfRules];

            for (var r = 0; r < noOfRules; r++)
            {
                includes[r] = new List<int>();
                for (var p = 0; p < rulePosition.Length; p++)
                {
                    if (validTickets.All(ticket => set.rules[r].IsOk(ticket[p])))
                    {
                        includes[r].Add(p);
                    }
                }
            }

            var found = 0;
            var column = new int[noOfRules];
            while (found < noOfRules)
            {
                for (var position = 0; position < noOfRules; position++)
                {
                    var includedIn = includes
                        .Select((list, ind) => (contains: list.Contains(position), indexOf: ind))
                        .Where(p => p.contains)
                        .ToArray();

                    if (includedIn.Length == 1)
                    {
                        var onlyIn = includedIn.First().indexOf;

                        found++;
                        column[onlyIn] = position;
                        includes[onlyIn] = new List<int>();
                        foreach (var inc in includes.Where(i => i.Contains(position)))
                            inc.Remove(position);
                    }
                }
            }

            var total = 1L;

            for (var r = 0; r < noOfRules; r++)
            {
                if (set.rules[r].Name.StartsWith("departure"))
                {
                    total *= set.ticket[column[r]];
                }
            }

            return total;
        }

        private (Rule[] rules, int[] ticket, int[][] nearby) Decode (string input)
        {
            var split1 = input.Split(Environment.NewLine + Environment.NewLine + "your ticket:" + Environment.NewLine);
            var split2 = split1[1].Split(Environment.NewLine + "nearby tickets:" + Environment.NewLine);

            var rules = split1[0].Split(Environment.NewLine).Select(l=>new Rule(l)).ToArray();

            var ticket = split2[0].Split(',').Select(int.Parse).ToArray();

            var nearby = split2[1].Split(Environment.NewLine)
                .Select(p => p.Split(',').Select(int.Parse).ToArray())
                .ToArray();

            return (rules, ticket, nearby);
        }

        private bool AnyValid(int value, Rule[] rules) => rules.Any(r => r.IsOk(value));

        private class Rule
        {
            public readonly string Name;
            private readonly (int, int)[] _range;

            public Rule(string data)
            {
                var split = data.Split(": ");
                var split2 = split[1].Split(" or ");
                Name = split[0];
                _range = new (int, int)[2];
                for (var i = 0; i < 2; i++)
                {
                    var range = split2[i].Split("-").Select(int.Parse).ToArray();
                    _range[i] = (range[0], range[1]);
                }
            }

            public bool IsOk(int value) =>
                (value >= _range[0].Item1 && value <= _range[0].Item2)
                || (value >= _range[1].Item1 && value <= _range[1].Item2);

        }
    }
}
