using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent
{
    public class Day18
    {
        public long SumOfWithNoPrecedence(string input)
        {
            var data = input.Split(Environment.NewLine).ToArray();

            return data.Sum(e=>Calculate(e,false));
        }
       
        public long SumOfAddTakesPrecedence(string input)
        {
            var data = input.Split(Environment.NewLine).ToArray();

            return data.Sum(e=>Calculate(e, true));
        }

        public long Calculate(string input, bool precedence)
        {
            var parts = input
                .Replace("(", "( ")
                .Replace(")", " )")
                .Split(' ')
                .Select(p => new Part(p))
                .ToArray();

            return SplitBrackets(parts, precedence);
        }


        private long SplitBrackets(Part[] data, bool precedence)
        {
            while (true)
            {
                var b = IndexOf(data, '(');
                if (b != -1)
                {
                    var brackets = 1;
                    for (var e = b + 1; e <= data.Length; e++)
                    {
                        if (data[e].Op == '(')
                        {
                            brackets++;
                        }
                        else if (data[e].Op == ')')
                        {
                            brackets--;
                            if (brackets == 0)
                            {
                                var part = data.Skip(b + 1).Take(e - b - 1).ToArray();

                                data = Replace(data, b, e,
                                    new Part(SplitBrackets(part, precedence)));

                                break;
                            }
                        }
                    }
                }

                else
                {
                    return Equate(data, precedence);
                }
            }
        }

        private int IndexOf(Part[] data, char search)
        {
            for (var p = 0; p < data.Length; p++)
                if (data[p].Op == search)
                    return p;
            return -1;
        }

        private Part[] Replace(Part[] data, int from, int to, Part with)
        {
            var dataLeft = data.Take(from).ToArray();
            var dataRight = data.Skip(to + 1).ToArray();

            return dataLeft.Append(with).Concat(dataRight).ToArray();
        }

        private long Equate(Part[] data, bool precedence)
        {
            while (precedence)
            {
                var b = IndexOf(data, '+');
                if (b == -1) break;

                var valueSum = data[b - 1].Value + data[b + 1].Value;

                data = Replace(data, b - 1, b + 1, new Part(valueSum));
            }

            var answer = data[0].Value;
            for (var p = 1; p < data.Length; p += 2)
            {
                var next = data[p + 1].Value;
                answer = data[p].Op switch
                {
                    '+' => answer + next,
                    '*' => answer * next,
                    _ => answer
                };
            }

            return answer;
        }

        private readonly struct Part
        {
            public readonly long Value;
            public readonly char Op;

            public Part(long value)
            {
                Value = value;
                Op = ' ';
            }

            public Part(string value)
            {
                if (char.IsDigit(value[0]))
                {
                    Value = long.Parse(value);
                    Op = ' ';
                }
                else
                {
                    Value = 0;
                    Op = value[0];
                }
            }
        }
    }
}
