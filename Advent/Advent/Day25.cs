using System;
using System.Linq;

namespace Advent
{
    public class Day25
    {
        public long EncryptionKey(string input)
        {
            var keys = input.Split(Environment.NewLine).Select(int.Parse).ToArray();

            var doorSecret = FindSecret(7, keys[0]);

            return EncryptionKey(keys[1], doorSecret);
        }

        private int FindSecret(long subject, long target)
        {
            var loop = 0;
            var value = 1L;
            while (value != target)
            {
                loop++;
                value = OneLoop(value, subject);
            }

            return loop;
        }

        private long OneLoop(long value, long subject) => (value * subject) % 20201227;
        
        private long EncryptionKey(long subject, int loop)
        {
            var value = 1L;
            for (var i = 0; i < loop; i++)
            {
                value = OneLoop(value, subject);
            }

            return value;
        }
    }
}
