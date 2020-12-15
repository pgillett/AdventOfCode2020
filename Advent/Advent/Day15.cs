using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day15
    {
        public int Find(int toTurn, string input)
        {
            var values = input
                .Split(',')
                .Select(l => int.Parse(l))
                .ToArray();

            var position = new Dictionary<int, int>();

            for (var i = 0; i < values.Length - 1; i++)
                position[values[i]] = i;

            var currentPosition = values.Length - 1;
            var lastSpoken = values.Last();

            while (currentPosition < toTurn - 1)
            {
                if (position.ContainsKey(lastSpoken))
                {
                    var lastPosition = position[lastSpoken];
                    position[lastSpoken] = currentPosition;
                    lastSpoken = currentPosition - lastPosition;
                }
                else
                {
                    position[lastSpoken] = currentPosition;
                    lastSpoken = 0;
                }

                currentPosition++;
            }

            return lastSpoken;
        }
    }
}
