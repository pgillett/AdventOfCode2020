using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent
{
    public class Day04
    {
        public string[] FileToPassports(string file) => file
                .Split(Environment.NewLine + Environment.NewLine)
                .Select(l => l.Replace(Environment.NewLine, " "))
                .ToArray();

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

        private bool IsValidPassport(string passport, bool basicValidate) =>
            passport
                .Split(' ')
                .Where(section => section.Length >= 3)
                .Select(section => section.Split(':'))
                .Select(parts => (type: parts[0], data: parts[1]))
                .Where(pair => Array.IndexOf(ExpectedFields, pair.type) >= 0)
                .Count(pair => basicValidate || IsFullyValidated(pair.type, pair.data)) == 7;

        private bool IsFullyValidated(string type, string data)
        {
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
