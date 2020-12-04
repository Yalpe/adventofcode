using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day4
    {
        public Day4()
        {
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var validPassports = CountValidPassports(new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd",
                "byr:1937 iyr:2017 cid:147 hgt:183cm",
                "",
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884",
                "hcl:#cfa07d byr:1929",
                "",
                "hcl:#ae17e1 iyr:2013",
                "eyr:2024",
                "ecl:brn pid:760753108 byr:1931",
                "hgt:179cm",
                "",
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr:2011 ecl:brn hgt:59in"
            });
            Console.WriteLine($"Answer is: {validPassports}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var validPassports = CountValidPassports(PuzzleInput.FetchStringArrayRaw(4));
            Console.WriteLine($"Answer is: {validPassports}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var validPassports = CountValidPassports2(new[]
            {
                "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980",
                "hcl:#623a2f",
                "",
                "eyr:2029 ecl:blu cid:129 byr:1989",
                "iyr:2014 pid:896056539 hcl:#a97842 hgt:165cm",
                "",
                "hcl:#888785",
                "hgt:164cm byr:2001 iyr:2015 cid:88",
                "pid:545766238 ecl:hzl",
                "eyr:2022",
                "",
                "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719"
            });
            Console.WriteLine($"Answer is: {validPassports}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            var validPassports = CountValidPassports2(PuzzleInput.FetchStringArrayRaw(4));
            Console.WriteLine($"Answer is: {validPassports}");
            Console.WriteLine();
        }

        public int CountValidPassports(string[] data)
        {
            var i = 0;
            var passports = new List<IDictionary<string, string>>();
            while (i < data.Length)
            {
                var passport = new Dictionary<string, string>();
                while (i < data.Length && !string.IsNullOrEmpty(data[i]))
                {
                    var keyValues = data[i].Split(' ');
                    foreach (var keyValue in keyValues)
                    {
                        var splitKV = keyValue.Split(':');
                        passport.Add(splitKV[0], splitKV[1]);
                    }

                    ++i;
                }

                passports.Add(passport);

                ++i;
            }

            return passports.Where(x =>  x.Count == 8 || (x.Count == 7 && !x.ContainsKey("cid"))).Count();
        }
        public int CountValidPassports2(string[] data)
        {
            var i = 0;
            var passports = new List<IDictionary<string, string>>();
            while (i < data.Length)
            {
                var passport = new Dictionary<string, string>();
                while (i < data.Length && !string.IsNullOrEmpty(data[i]))
                {
                    var keyValues = data[i].Split(' ');
                    foreach (var keyValue in keyValues)
                    {
                        var splitKV = keyValue.Split(':');
                        passport.Add(splitKV[0], splitKV[1]);
                    }

                    ++i;
                }

                passports.Add(passport);

                ++i;
            }

            var validPassports = 0;
            foreach (var passport in passports)
            {
                if (passport.Count < 7)
                    continue;
                
                if (passport.Count == 7 && passport.ContainsKey("cid"))
                    continue;
                
                var birthYear = int.Parse(passport["byr"]);
                if (birthYear < 1920 || birthYear > 2020)
                    continue;

                var issueYear = int.Parse(passport["iyr"]);
                if (issueYear < 2010 || issueYear > 2020)
                    continue;

                var expirationYear = int.Parse(passport["eyr"]);
                if (expirationYear < 2020 || expirationYear > 2030)
                    continue;

                var regex = new Regex(@"(\d*)(cm|in)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var heightMatches = regex.Matches(passport["hgt"]);
                if (heightMatches.Count() != 1)
                    continue;
                
                var height = int.Parse(heightMatches[0].Groups[1].Value);
                if (heightMatches[0].Groups[2].Value == "cm" && (height < 150 || height > 193))
                    continue;
                if (heightMatches[0].Groups[2].Value == "in" && (height < 59 || height > 76))
                    continue;

                regex = new Regex(@"^#(\d|[a-f]){6}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var hairColorMatches = regex.Matches(passport["hcl"]);
                if (hairColorMatches.Count() != 1)
                    continue;

                var eyeColors = new HashSet<string> { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                if (!eyeColors.Contains(passport["ecl"]))
                    continue;

                regex = new Regex(@"^(\d){9}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                var passportId = regex.Matches(passport["pid"]);
                if (passportId.Count() != 1)
                    continue;

                ++validPassports;
            }

            return validPassports;
        }
    }
}