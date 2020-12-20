using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Advent
{
    public class Day20
    {
        public long CornerMultiply(string input)
        {
            var arrangement = new Arrangement(input);

            var arrange = arrangement.Layout;

            return 1L * arrange[(arrangement.Bounds.min.x, arrangement.Bounds.min.y)].Piece.Id
                      * arrange[(arrangement.Bounds.max.x, arrangement.Bounds.min.y)].Piece.Id
                      * arrange[(arrangement.Bounds.min.x, arrangement.Bounds.max.y)].Piece.Id
                      * arrange[(arrangement.Bounds.max.x, arrangement.Bounds.max.y)].Piece.Id;
        }

        public int SeaMonsters(string input)
        {
            var arrangement = new Arrangement(input);

            var monsters = new Monsters(arrangement);

            return monsters.Rough;
        }

        private class Arrangement
        {
            public readonly Dictionary<(int x, int y), OrientedPiece> Layout = new Dictionary<(int, int), OrientedPiece>();
            
            public readonly ((int x, int y) min, (int x, int y) max) Bounds;

            public int JoinSize => (Bounds.max.x - Bounds.min.x + 1) * InnerSize;

            private int InnerSize => _pieces[0].Size - 2;

            private readonly Queue<(int x, int y)> _queue = new Queue<(int, int)>();

            private readonly Piece[] _pieces;

            public Arrangement(string input)
            {
                _pieces = input
                    .Split(Environment.NewLine + Environment.NewLine)
                    .Select(p => new Piece(p))
                    .ToArray();

                Layout[(0, 0)] = new OrientedPiece(_pieces[0], Orientation.SetOf[0]);
                _queue.Enqueue((0, 0));

                while (_queue.Count > 0)
                {
                    var pos = _queue.Dequeue();
                    if (Layout.ContainsKey(pos))
                    {
                        var atPos = Layout[pos];
                        CheckAndAddToQueue(atPos, pos.x, pos.y - 1, CheckAbove);
                        CheckAndAddToQueue(atPos, pos.x, pos.y + 1, CheckBelow);
                        CheckAndAddToQueue(atPos, pos.x + 1, pos.y, CheckRight);
                        CheckAndAddToQueue(atPos, pos.x - 1, pos.y, CheckLeft);
                    }
                }

                Bounds = ((Layout.Keys.Min(k => k.x), Layout.Keys.Min(k => k.y)),
                    (Layout.Keys.Max(k => k.x), Layout.Keys.Max(k => k.y)));
            }

            private void CheckAndAddToQueue(OrientedPiece piece, int x, int y,
                Func<OrientedPiece, Piece, Orientation, bool> action)
            {
                if (!Layout.ContainsKey((x, y)))
                {
                    var next = FindPiece(piece, action);
                    if (next != null)
                    {
                        Layout[(x, y)] = next;
                        _queue.Enqueue((x, y));
                    }
                }
            }

            private OrientedPiece FindPiece(OrientedPiece main, Func<OrientedPiece, Piece, Orientation, bool> action) =>
                _pieces.Where(p => p != main.Piece)
                    .Select(p => new OrientedPiece(p, FindOrient(main, p, action)))
                    .SingleOrDefault(p => p.Orientation != null);

            private Orientation FindOrient(OrientedPiece main, Piece beside, Func<OrientedPiece, Piece, Orientation, bool> action) 
                => Orientation.SetOf.FirstOrDefault(orient => action(main, beside, orient));

            private bool CheckAbove(OrientedPiece main, Piece above, Orientation orientationAbove) => 
                _range.All(p => main.At(p, 0) == above.At(p, 9, orientationAbove));

            private bool CheckBelow(OrientedPiece main, Piece below, Orientation orientationBelow) => 
                _range.All(p => main.At(p, 9) == below.At(p, 0, orientationBelow));

            private bool CheckLeft(OrientedPiece main, Piece left, Orientation orientationLeft) =>
                _range.All(p => main.At(0, p) == left.At(9, p, orientationLeft));

            private bool CheckRight(OrientedPiece main, Piece right, Orientation orientationRight) => 
                _range.All(p => main.At(9, p) == right.At(0, p, orientationRight));

            private readonly IEnumerable<int> _range = Enumerable.Range(0, 10);

            public bool At(int origX, int origY, Orientation orientation)
            {
                var (x, y) = orientation.Move(origX, origY, JoinSize);

                return Layout[(x / InnerSize + Bounds.min.x, y / InnerSize + Bounds.min.y)]
                    .At(x % InnerSize + 1, y % InnerSize + 1);
            }
        }

        private class Monsters
        {
            private readonly Arrangement _arrangement;

            private readonly HashSet<(int, int)> _found;

            public readonly int Rough;
            
            public Monsters(Arrangement arrange)
            {
                _arrangement = arrange;

                _found = new HashSet<(int, int)>();

                foreach (var orientation in Orientation.SetOf)
                {
                    FindSeaMonster(orientation);
                }

                for (var y = 0; y < _arrangement.JoinSize; y++)
                    for (var x = 0; x < _arrangement.JoinSize; x++)
                    {
                        if (_arrangement.At(x, y, Orientation.SetOf[0]))
                        {
                            if (!_found.Contains((x, y)))
                                Rough++;
                        }
                    }
            }

            private void FindSeaMonster(Orientation orientation)
            {
                for (var y = 0; y <= _arrangement.JoinSize - _monster.Length; y++)
                for (var x = 0; x <= _arrangement.JoinSize - _monster[0].Length; x++)
                    CheckMonsterAt(orientation, x, y);
            }

            private void CheckMonsterAt(Orientation orientation, int sx, in int sy)
            {
                for (var y = 0; y < _monster.Length; y++)
                for (var x = 0; x < _monster[0].Length; x++)
                    if (_monster[y][x] == '#' && !_arrangement.At(sx + x, sy + y, orientation))
                        return;
                for (var y = 0; y < _monster.Length; y++)
                for (var x = 0; x < _monster[0].Length; x++)
                {
                    if (_monster[y][x] == '#')
                    {
                        _found.Add(orientation.Move(sx + x, sy + y, _arrangement.JoinSize));
                    }
                }
            }
            
            private readonly string[] _monster = {
                "                  # ",
                "#    ##    ##    ###",
                " #  #  #  #  #  #   "
            };
        }
        
        private class OrientedPiece
        {
            public readonly Piece Piece;
            public readonly Orientation Orientation;

            public OrientedPiece(Piece piece, Orientation orientation)
            {
                Piece = piece;
                Orientation = orientation;
            }

            public bool At(int x, int y) => Piece.At(x, y, Orientation);
        }

        private class Orientation
        {
            private readonly bool _flipX;
            private readonly bool _flipY;
            private readonly bool _turn;

            public Orientation(bool flipX, bool flipY, bool turn)
            {
                _flipX = flipX;
                _flipY = flipY;
                _turn = turn;
            }

            public (int x, int y) Move(int x, int y, int size)
            {
                if (_flipX)
                {
                    x = size - 1 - x;
                }

                if (_flipY)
                {
                    y = size - 1 - y;
                }

                if (_turn)
                {
                    var t = y;
                    y = x;
                    x = size - 1 - t;
                }

                return (x, y);
            }

            public static readonly Orientation[] SetOf =
                Enumerable.Range(0, 8)
                    .Select(i => new Orientation((i & 1) != 0, (i & 2) != 0, (i & 4) != 0))
                    .ToArray();
        }

        private class Piece
        {
            public readonly int Id;

            private readonly bool[][] _picture;

            public int Size => _picture[0].Length;

            public Piece(string data)
            {
                var split = data.Split(Environment.NewLine);
                Id = int.Parse(split[0].Substring(5, 4));
                _picture=split
                    .Skip(1)
                    .Select(l => l.Select(x => x == '#')
                        .ToArray())
                    .ToArray();
                
            }

            public bool At(int x, int y, Orientation orientation)
            {
                var pos = orientation.Move(x, y, Size);
                return _picture[pos.y][pos.x];
            }
        }
    }
    
}
