using System;
using System.Linq;

namespace Advent
{
    public class Day05
    {
        public int FindSeatId(string input)
        {
            var seats = new bool[128 * 8];

            var boardings = input.Split(Environment.NewLine);

            foreach (var boarding in boardings)
            {
                seats[SeatId(boarding)] = true;
            }

            for (int id = 1 * 8; id <= 126 * 8 + 7; id++)
            {
                if (seats[id] == false && seats[id - 1] && seats[id + 1])
                {
                    return id;
                }
            }

            return 0;
        }

        public int HighestSeatId(string input)
        {
            var boardings = input.Split(Environment.NewLine);

            return boardings.Max(SeatId);
        }

        public int SeatId(string boarding) => Decode(boarding).id;

        public (int row, int column, int id) Decode(string boarding)
        {
            var row = DecodePart(boarding.Substring(0, 7), 'B');
            var col = DecodePart(boarding.Substring(7, 3), 'R');

            return (row, col, row * 8 + col);
        }

        public int DecodePart(string data, char top) => 
            data.Aggregate(0, (current, code) => (current << 1) | (code == top ? 1 : 0));
    }
}
