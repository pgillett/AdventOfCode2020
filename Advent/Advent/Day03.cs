using System;
using System.Linq;

namespace Advent
{
    
    public class Day03
    {
        public long CountMultiples(string input)
        {
            return new (int right, int down)[] {(1, 1), (3, 1), (5, 1), (7, 1), (1, 2)}
                .Aggregate(1L, (current, pair) => current * Count(input, pair.right, pair.down));
        }

        public int CountRight3Down1(string input)
        {
            return Count(input, 3, 1);
        }

        private int Count(string input, int right, int down)
        {
            var lines = input.Split(Environment.NewLine);

            var count = 0;
            var col = 0;
            for (var row = 0; row < lines.Length; row += down, col += right)
            {
                if (IsTreeAt(lines, row, col)) count++;
            }

            return count;
        }

        public bool IsTreeAt(string[] lines, int row, int col) => 
            lines[row][col % lines[0].Length] == '#';
    }
}