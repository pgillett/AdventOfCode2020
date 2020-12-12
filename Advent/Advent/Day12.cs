using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day12
    {
        public int Manhattan(string input)
        {
            var instructions = Decode(input);

            var ship = new Ship(Direction.East, 0, 0);

            foreach (var i in instructions)
                ship = ship.Move(i);

            return ship.Manhattan();
        }

        public int ManhattanWaypoint(string input)
        {
            var instructions = Decode(input);

            var ship = new Ship(Direction.None, 0,0);
            var wayPoint = new Waypoint(10, 1);

            foreach (var i in instructions)
            {
                wayPoint = wayPoint.Move(i);
                ship = ship.MoveTowards(i, wayPoint);
            }

            return ship.Manhattan();
        }

        public enum Direction { North, East, South, West, None }

        private IEnumerable<Instruction> Decode(string input) =>
            input
                .Split(Environment.NewLine)
                .Select(l => new Instruction(l));
        
        public struct Instruction
        {
            public readonly string Full;

            public Instruction(string full)
            {
                Full = full;
            }

            public char Code => Full[0];
            public int Value => int.Parse(Full.Substring(1));
        }

        public struct Ship
        {
            public readonly Direction Direction;
            public readonly int X;
            public readonly int Y;
            public int Manhattan() => Math.Abs(X) + Math.Abs(Y);

            public Ship(Direction direction, int x, int y)
            {
                Direction = direction;
                X = x;
                Y = y;
            }

            public Ship Move(Instruction instruction)
            {
                var v = instruction.Value;
                return instruction.Code switch
                {
                    'N' => MovedBy(0, v),
                    'S' => MovedBy(0, -v),
                    'E' => MovedBy(v, 0),
                    'W' => MovedBy(-v, 0),
                    'F' => MovedBy(
                        v * (Direction == Direction.East ? 1 : Direction == Direction.West ? -1 : 0),
                        v * (Direction == Direction.North ? 1 : Direction == Direction.South ? -1 : 0)),
                    'L' => Rotated(-v),
                    'R' => Rotated(v),
                    _ => this
                };
            }

            private Ship MovedBy(int x, int y) => new Ship(Direction, X + x, Y + y);

            private Ship Rotated(int degrees) =>
                new Ship((Direction) (((int) Direction + 4 + degrees / 90) % 4), X, Y);

            public Ship MoveTowards(Instruction instruction, Waypoint waypoint)
            {
                if (instruction.Code != 'F') return this;
                
                var v = instruction.Value;
                return MovedBy(v * waypoint.X, v * waypoint.Y);
            }
        }

        public struct Waypoint
        {
            public readonly int X;
            public readonly int Y;

            public Waypoint(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Waypoint Move(Instruction instruction) =>
                instruction.Code switch
                {
                    'N' => new Waypoint(X, Y + instruction.Value),
                    'S' => new Waypoint(X, Y - instruction.Value),
                    'E' => new Waypoint(X + instruction.Value, Y),
                    'W' => new Waypoint(X - instruction.Value, Y),
                    'R' => Rotate(instruction),
                    'L' => Rotate(instruction),
                    _ => this
                };

            private Waypoint Rotate(Instruction instruction)
            {
                ((int x, int y) x, (int x, int y) y) dp = instruction.Full switch
                {
                    "R0" => ((1, 0), (0, 1)),
                    "L0" => ((1, 0), (0, 1)),
                    "R90" => ((0, 1), (-1, 0)),
                    "L270" => ((0, 1), (-1, 0)),
                    "L180" => ((-1, 0), (0, -1)),
                    "R180" => ((-1, 0), (0, -1)),
                    "R270" => ((0, -1), (1, 0)),
                    "L90" => ((0, -1), (1, 0)),
                    _ => ((0, 0), (0, 0))
                };

                return new Waypoint(X * dp.x.x + Y * dp.x.y, 
                    X * dp.y.x + Y * dp.y.y);
            }
        }
    }
}
