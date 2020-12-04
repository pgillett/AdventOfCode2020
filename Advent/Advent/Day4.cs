using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent
{
    public class Day4
    {
        public string[] FileToPassports(string file)
        {
            var list = new List<StringBuilder>();

            var fileLines = file.Split(Environment.NewLine);
            StringBuilder current = null;

            foreach (var line in fileLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    current = null;
                }
                else
                {
                    if (current == null)
                    {
                        current = new StringBuilder();
                        list.Add(current);
                    }

                    current.Append(" ").Append(line.Trim());
                }
            }

            return list.Select(l => l.ToString().Trim()).ToArray();
        }

        public int CountBasicValidPassports(string file)
        {
            var passports = FileToPassports(file);

            return passports.Count(p => IsValidPassport(p, true));
        }

        public int CountFullyValidatedPassports(string file)
        {
            var passports = FileToPassports(file);

            return passports.Count(p => IsValidPassport(p, false));
        }

        public bool IsValidPassport(string passport, bool basicValidate)
        {
            var sections = passport.Split(' ');
            var found = new bool[ExpectedFields.Length];
            foreach (var section in sections.Where(s => s.Length >= 3))
            {
                var field = Array.IndexOf(ExpectedFields, section.Substring(0, 3));
                if (field >= 0)
                    found[field] = basicValidate || IsFullyValidated(ExpectedFields[field], section);
            }

            return found.Count(f => f) == 7;
        }

        public bool IsFullyValidated(string type, string data)
        {
            data = data.Split(':')[1];
            switch (type)
            {
                case "byr":
                    var birthYear = int.Parse(data);
                    return birthYear >= 1920 && birthYear <= 2002;
                case "iyr":
                    var issueYear = int.Parse(data);
                    return issueYear >= 2010 && issueYear <= 2020;
                case "eyr":
                    var expirationYear = int.Parse(data);
                    return expirationYear >= 2020 && expirationYear <= 2030;
                case "hgt":
                    if (data.Length < 4) return false;
                    var value = int.Parse(data.Substring(0, data.Length - 2));
                    var unit = data.Substring(data.Length - 2);
                    return (unit == "cm" && value >= 150 && value <= 193) ||
                           (unit == "in" && value >= 59 && value <= 76);
                case "hcl":
                    return data.Length == 7 && data[0] == '#' &&
                           data.Count(c => "0123456789abcdef".Contains(c)) == 6;
                case "ecl":
                    return new[] {"amb", "blu", "brn", "gry", "grn", "hzl", "oth"}.Contains(data);
                case "pid":
                    return data.Count(char.IsDigit) == 9;

                default:
                    throw new Exception("Not implemented");
            }
        }

        private string[] ExpectedFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

    }
}
