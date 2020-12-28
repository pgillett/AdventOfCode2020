using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day15
    {
        public int FindDictionary(int toTurn, string input)
        {
            // Original solution
            
            var values = input
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var position = new Dictionary<int, int>();

            for (var i = 0; i < values.Length - 1; i++)
                position[values[i]] = i;

            var currentPosition = values.Length - 1;
            var lastSpoken = values.Last();

            while (currentPosition < toTurn - 1)
            {
                if (position.TryGetValue(lastSpoken, out var lastPosition))
                {
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
        
        public int Find(int toTurn, string input)
        {
            // Quicker. Appears to also be more memory efficient even with the big array
            
            var values = input
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            var position = new int[toTurn];
            for (var i = 0; i < position.Length; i++)
                position[i] = -1;

            for (var i = 0; i < values.Length - 1; i++)
                position[values[i]] = i;

            var currentPosition = values.Length - 1;
            var lastSpoken = values.Last();

            while (currentPosition < toTurn - 1)
            {
                if (position[lastSpoken]>=0)
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
