using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day22
    {
        public int WinningScore(string input)
        {
            return Play(input, false);
        }

        public int RecursiveWinningScore(string input)
        {
            return Play(input, true);
        }

        private int Play(string input, bool subGames)
        {
            var split = input.Split(Environment.NewLine + Environment.NewLine
                                                        + "Player 2:"
                                                        + Environment.NewLine);

            var player2 = split[1]
                .Split(Environment.NewLine)
                .Select(int.Parse);
            var player1 = split[0]
                .Split(Environment.NewLine)
                .Skip(1)
                .Select(int.Parse);

            var (player, cards) = SubGame(player1, player2, subGames);
            return Score(cards.ToArray());
        }

        private int Score(int[] cards) => cards.Select((t, i) => (cards.Length - i) * t).Sum();


        private (int player, IEnumerable<int> cards) SubGame(IEnumerable<int> player1, IEnumerable<int> player2, bool subGames)
        {
            var decks = new Decks();

            var cards1 = new Queue<int>(player1);
            var cards2 = new Queue<int>(player2);

            while (cards1.Count != 0 && cards2.Count != 0)
            {
                if (decks.HasPlayed(1, cards1) || decks.HasPlayed(2, cards2)) return (1, cards1);

                var c1 = cards1.Dequeue();
                var c2 = cards2.Dequeue();

                int winner;
                if (subGames && cards1.Count >= c1 && cards2.Count >= c2)
                {
                    winner = SubGame(cards1.Take(c1), cards2.Take(c2), subGames).player;
                }
                else
                {
                    winner = c1 > c2 ? 1 : 2;
                }

                if (winner == 1)
                {
                    cards1.Enqueue(c1);
                    cards1.Enqueue(c2);
                }
                else
                {
                    cards2.Enqueue(c2);
                    cards2.Enqueue(c1);
                }
            }

            return cards1.Count > 0 ? (1, cards1) : (2, cards2);
        }
        
        private class Decks
        {
            private readonly List<(int, int[])> _decks = new List<(int, int[])>();

            public bool HasPlayed(int player, IEnumerable<int> deck)
            {
                var set = deck.ToArray();
                foreach (var played in _decks.Where(d => d.Item1 == player
                                                         && d.Item2.Length == set.Length))
                {
                    for (int i = 0; i <= set.Length; i++)
                    {
                        if (i == set.Length)
                            return true;
                        if (set[i] != played.Item2[i])
                            break;
                    }
                }

                _decks.Add((player, set));
                return false;
            }

        }
    }
}
