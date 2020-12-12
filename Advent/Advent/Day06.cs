using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent
{
    public class Day06
    {
        public int CountGroupQuestions(string input)
        {
            var groupsOfPeople = ParseData(input);

            return groupsOfPeople.Sum(CountAllInGroup);
        }

        public int CountMatchingInGroupQuestions(string input)
        {
            var groupsOfPeople = ParseData(input);

            return groupsOfPeople.Sum(CountMatchInGroup);
        }

        private int CountAllInGroup(IEnumerable<string> persons) =>
            String.Join("", persons)
                .Distinct()
                .Count();

        private int CountMatchInGroup(IEnumerable<string> persons) =>
            persons.First()
                .Distinct()
                .Count(question => persons.All(p => p.Contains(question)));

        private IEnumerable<IEnumerable<string>> ParseData(string input) =>
            input.Split(Environment.NewLine + Environment.NewLine)
                .Select(people => people.Split(Environment.NewLine));
    }
}
