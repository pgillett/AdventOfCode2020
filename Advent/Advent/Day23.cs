namespace Advent
{
    public class Day23
    {
        public string TextFrom1(string input, int goes)
        {
            var cups = new Cups(input, input.Length);

            for (var i = 0; i < goes; i++)
                cups.Move();

            return cups.TextFrom1;
        }

        public long RightMultiply(string input, int goes)
        {
            var cups = new Cups(input, 1000000);

            for (var i = 0; i < goes; i++)
                cups.Move();

            return cups.RightMultiply;
        }

        private class Cups
        {
            private readonly int[] _data;

            private int _current;
            
            private readonly int _size;
            
            public Cups(string data, int size)
            {
                _size = size;
                _data = new int[_size + 1];

                var temp = new int[_size + 1];
                for (int i = 1; i < temp.Length; i++)
                    temp[i] = i;
                for (int i = 0; i < data.Length; i++)
                    temp[i + 1] = data[i] - '0';

                for (int i = _size - 1; i > 0; i--)
                    _data[temp[i]] = temp[i + 1];

                _data[temp[_size]] = temp[1];

                _current = data[0] - '0';
            }
            
            public string TextFrom1
            {
                get
                {
                    var ret = "";
                    var pos = _data[1];
                    for (var i = 0; i < 8; i++)
                    {
                        ret += pos.ToString();
                        pos = _data[pos];
                    }
                    return ret;
                }
            }

            public long RightMultiply
            {
                get
                {
                    var right1 = (long)_data[1];
                    var right2 = (long)_data[right1];
                    return right1 * right2;
                }
            }

            public void Move()
            {
                var cup1 = _data[_current];
                var cup2 = _data[cup1];
                var cup3 = _data[cup2];
                
                _data[_current] = _data[cup3];
                
                var destination = _current;
                while (true)
                {
                    if (--destination == 0) destination = _size;
                    if (destination != cup1 && destination != cup2 && destination != cup3)
                        break;
                }

                var toRightOfDestination = _data[destination];
                _data[cup3] = toRightOfDestination;
                
                _data[destination] = cup1;

                _current = _data[_current];
            }
        }
    }
}
