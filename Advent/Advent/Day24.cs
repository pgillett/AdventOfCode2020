using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day24
    {
        public int CountBlack(string input)
        {
            var tiles = Flip(input);

            return tiles.Count;
        }

        public int CountBlack100Days(string input)
        {
            var tiles = Flip(input);
            
            for (var i = 0; i < 100; i++)
            {
                tiles = GameOfLife(tiles);
            }

            return tiles.Count;
        }

        private HashSet<(int, int)> Flip(string input)
        {
            var tiles = new HashSet<(int, int)>();
            foreach (var instructions in Decode(input))
            {
                var x = 0;
                var y = 0;
                foreach (var step in instructions)
                {
                    var (dx, dy) = _directions[step];
                    x += dx;
                    y += dy;
                }

                if (tiles.Contains((x, y)))
                {
                    tiles.Remove((x, y));
                }
                else
                {
                    tiles.Add((x, y));
                }
            }

            return tiles;
        }

        private HashSet<(int, int)> GameOfLife(HashSet<(int, int)> tiles)
        {
            var newTiles = new HashSet<(int, int)>();

            var minX = tiles.Min(p => p.Item1) - 2;
            var maxX = tiles.Max(p => p.Item1) + 2;

            var minY = tiles.Min(p => p.Item2) - 1;
            var maxY = tiles.Max(p => p.Item2) + 1;

            if (minY % 2 != minX % 2) minX--;

            for (var y = minY; y <= maxY; y++)
            {
                for (var x = minX - (y % 2); x <= maxX; x++)
                {
                    var count = _directions.Values
                        .Count(direction => 
                            tiles.Contains((x + direction.Item1, y + direction.Item2)));
                    
                    if (count == 2 || (tiles.Contains((x, y)) && count == 1))
                        newTiles.Add((x, y));
                }
            }

            return newTiles;
        }

        private string[][] Decode(string input) =>
            input.Split(Environment.NewLine)
                .Select(DecodeLine)
                .ToArray();

        private string[] DecodeLine(string data)
        {
            var list = new List<string>();

            while (data.Length > 0)
            {
                foreach (var direction in _directions.Keys
                    .Where(direction => data.StartsWith(direction)))
                {
                    list.Add(direction);
                    data = data.Substring(direction.Length);
                }
            }

            return list.ToArray();
        }

        private readonly Dictionary<string, (int, int)> _directions = new Dictionary<string, (int, int)>
        {
            {"e", (-2, 0)},
            {"w", (2, 0)},
            {"ne", (-1, -1)},
            {"nw", (1, -1)},
            {"se", (-1, 1)},
            {"sw", (1, 1)}
        };
    }
}
