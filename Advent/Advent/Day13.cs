using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Advent
{
    public class Day13
    {
        public int FindEarliest(string input)
        {
            var split = input.Split(Environment.NewLine);

            var depart = int.Parse(split[0]);

            var buses = split[1]
                .Split(',')
                .Where(id => id != "x")
                .Select(id => int.Parse(id));

            var earliest = buses
                .Select(bus => (id: bus, wait: WaitTilNext(bus, depart)))
                .OrderBy(bus => bus.wait)
                .First();

            return earliest.id * earliest.wait;
        }

        private int WaitTilNext(int id, int depart)
        {
            var closest = (depart / id) * id;
            return (closest - depart + id) % id;
        }

        public long FindSequential(string input)
        {
            var split = input.Split(Environment.NewLine);

            var buses = split[1]
                .Split(',')
                .Select(bus => bus == "x" ? 0 : int.Parse(bus))
                .ToArray();

            var totalInterval = 1L;
            var depart = 0L;
            for (int b = 0; b < buses.Length; b++)
            {
                if (buses[b] > 0)
                {
                    var searchTime = depart + b;
                    while (true)
                    {
                        searchTime += totalInterval;
                        var closest = (searchTime / buses[b]) * buses[b];
                        if (searchTime == closest)
                            break;
                    }

                    depart = searchTime - b;
                    totalInterval *= buses[b];
                }
            }

            return depart;
        }
    }
}
