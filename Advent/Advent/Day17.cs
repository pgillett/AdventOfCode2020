using System;
using System.Collections.Generic;

namespace Advent
{
    public class Day17
    {
        public int Active(int dimensions, string input)
        {
            var cubes = new Cubes(input);
            for (var c = 0; c < 6; c++)
                cubes = cubes.Process(dimensions);

            return cubes.Count;
        }

        public class Cubes
        {
            private HashSet<Position> Actives = new HashSet<Position>();

            public Cubes(string input)
            {
                var lines = input.Split(Environment.NewLine);

                for (var y = 0; y < lines.Length; y++)
                for (var x = 0; x < lines[y].Length; x++)
                    if (lines[y][x] == '#')
                        Actives.Add(new Position(x, y, 0, 0));
            }

            private Cubes()
            {}

            public Cubes Process(int dimension)
            {
                var range = GetRange(dimension);

                var newCubes = new HashSet<Position>();

                for (var x = range.Min.X; x <= range.Max.X; x++)
                for (var y = range.Min.Y; y <= range.Max.Y; y++)
                for (var z = range.Min.Z; z <= range.Max.Z; z++)
                for (var w = range.Min.W; w <= range.Max.W; w++)
                {
                    var pos = new Position(x, y, z, w);
                    var count = CountRound(pos);
                    var active = Actives.Contains(pos);
                    if ((active && (count == 2 || count == 3))
                        || (!active && count == 3))
                        newCubes.Add(pos);
                }

                return new Cubes() {Actives = newCubes};
            }
            
            private Range GetRange(int dimension)
            {
                var min = new Position(0, 0, 0, 0);
                var max = new Position(0, 0, 0, 0);
                foreach (var position in Actives)
                {
                    min = min.Min(position.X, position.Y, position.Z, position.W);
                    max = max.Max(position.X, position.Y, position.Z, position.W);
                }

                min = new Position(min.X - (dimension > 0 ? 1 : 0), min.Y - (dimension > 1 ? 1 : 0),
                    min.Z - (dimension > 2 ? 1 : 0), min.W - (dimension > 3 ? 1 : 0));

                max= new Position(max.X + (dimension > 0 ? 1 : 0), max.Y + (dimension > 1 ? 1 : 0),
                    max.Z + (dimension > 2 ? 1 : 0), max.W + (dimension > 3 ? 1 : 0));

                return new Range(min, max);
            }

            private int CountRound(Position position)
            {
                var count = 0;
                for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                for (var dz = -1; dz <= 1; dz++)
                for (var dw = -1; dw <= 1; dw++)
                    if (dx != 0 || dy != 0 || dz != 0 || dw != 0)
                    {
                        var pos = position.Add(dx, dy, dz, dw);
                        if (Actives.Contains(pos))
                            count++;
                    }

                return count;
            }

            public int Count => Actives.Count;
        }
        
        private readonly struct Position
        {
            public readonly int X;
            public readonly int Y;
            public readonly int Z;
            public readonly int W;

            public Position(int x, int y, int z, int w)
            {
                X = x;
                Y = y;
                Z = z;
                W = w;
            }

            public Position Max(int x, int y, int z, int w) =>
                new Position(Math.Max(X, x), Math.Max(Y, y), Math.Max(Z, z), Math.Max(W, w));

            public Position Min(int x, int y, int z, int w) =>
                new Position(Math.Min(X, x), Math.Min(Y, y), Math.Min(Z, z), Math.Min(W, w));

            public Position Add(int dx, int dy, int dz, int dw) =>
                new Position(X + dx, Y + dy, Z + dz, W + dw);
        }

        private readonly struct Range
        {
            public readonly Position Min;
            public readonly Position Max;

            public Range(Position min, Position max)
            {
                Min = min;
                Max = max;
            }
        }
    }
}
