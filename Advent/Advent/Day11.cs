using System;
using System.Linq;

namespace Advent
{
    public class Day11
    {
        public int SeatsAtEquilibriumNear(string input)
        {
            return FindEquilibrium(input, false, 4);
        }

        public int SeatsAtEquilibriumFurther(string input)
        {
            return FindEquilibrium(input, true, 5);
        }

        private int FindEquilibrium(string input, bool lookFurther, int max)
        {
            var seats = new SeatPlan(input);

            while (true)
            {
                var newSeats = new SeatPlan(seats);
                for (var row = 0; row < seats.MaxRow; row++)
                {
                    for (var col = 0; col < seats.MaxCol; col++)
                    {
                        var count = seats.CountRound(row, col, lookFurther);
                        if (seats.IsEmpty(row, col) && count == 0)
                        {
                            newSeats.Set(row, col, Seating.Full);
                        }
                        else if (seats.IsFull(row, col) && count >= max)
                        {
                            newSeats.Set(row, col, Seating.Empty);
                        }
                    }
                }

                seats = newSeats;
                if (!seats.Changed) return seats.CountFilled();
            }
        }

        public class SeatPlan
        {
            private Seating[,] _seats;
            public bool Changed;

            public SeatPlan(string input)
            {
                var lines = input.Split(Environment.NewLine);

                _seats = new Seating[lines.Length, lines[0].Length];

                for (var row = 0; row < MaxRow; row++)
                    for (var col = 0; col < MaxCol; col++)
                        _seats[row, col] = (Seating)lines[row][col];

            }

            public SeatPlan(SeatPlan seatPlan)
            {
                _seats = seatPlan._seats.Clone() as Seating[,];
            }

            public int CountFilled() =>
                _seats
                    .Cast<Seating>()
                    .Count(seat => seat == Seating.Full);

            public int MaxRow => _seats.GetLength(0);
            public int MaxCol => _seats.GetLength(1);

            public bool IsEmpty(int row, int col) => _seats[row, col] == Seating.Empty;
            public bool IsFull(int row, int col) => _seats[row, col] == Seating.Full;
            public Seating InPosition(int row, int col) => _seats[row, col];

            public void Set(int row, int col, Seating value)
            {
                Changed = true;
                _seats[row, col] = value;
            }

            public int CountRound(int row, int col, bool further) => further
                    ? CountFurther(row, col)
                    : CountNear(row, col);

            private int CountNear(int row, int col)
            {
                return _directions.Count(direction =>
                    Valid(row + direction.Item1, col + direction.Item2)
                    && IsFull(row + direction.Item1, col + direction.Item2));
            }

            private int CountFurther(int row, int col)
            {
                return _directions.Count(direction =>
                    CountFurtherDirection(row, col, direction.Item1, direction.Item2));
            }

            private bool CountFurtherDirection(int row, int col, int dr, int dc)
            {
                while (true)
                {
                    row += dr;
                    col += dc;

                    if (!Valid(row, col) || IsEmpty(row, col))
                        return false;

                    if (IsFull(row, col))
                    {
                        return true;
                    }
                }
            }

            private bool Valid(int row, int col) => row >= 0 && row < MaxRow
                                                             && col >= 0 && col < MaxCol;

            private (int, int)[] _directions = new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

        }

        public enum Seating
        {
            Floor = '.', Empty = 'L', Full = '#'
        }
    }
}
