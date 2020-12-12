using System;
using System.Linq;

namespace Advent
{
    public class Day02
    {
        public int CountCorrectPasswordsNumber(string passwordList)
        {
            var passwordSets = passwordList.Split(Environment.NewLine);

            return passwordSets.Count(p => IsValidNumber(p));
        }

        public int CountCorrectPasswordsPosition(string passwordList)
        {
            var passwordSets = passwordList.Split(Environment.NewLine);

            return passwordSets.Count(p => IsValidPosition(p));
        }

        public bool IsValidNumber(string passwordSet)
        {
            SplitPassword(passwordSet, out var minimum, out var maximum,
                out var character, out var password);

            var count = password.Count(c => c == character);

            return count >= minimum && count <= maximum;
        }

        public bool IsValidPosition(string passwordSet)
        {
            SplitPassword(passwordSet, out var position1, out var position2,
                out var character, out var password);

            return password[position1-1] == character ^ password[position2-1] == character;
        }

        public void SplitPassword(string passwordSet, out int value1, out int value2, 
            out char character, out string password)
        {
            var split = passwordSet.Split('-', ' ', ':');

            value1 = int.Parse(split[0]);
            value2 = int.Parse(split[1]);

            character = split[2][0];

            password = split[4].Trim();
        }
    }
}
