using System;
using System.Linq;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day2
    {
        private string[] _data;

        public Day2()
        {
            _data = PuzzleInput.FetchStringArray(2);
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" });
            Console.WriteLine();
        }
        
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Solve(_data);
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            Solve2(new[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data);
            Console.WriteLine();
        }

        public void Solve(string[] data)
        {
            var validPasswordCount = 0;
            foreach (var passwordAndPolicy in data)
            {
                var splitPasswordAndPolicy = passwordAndPolicy.Split(':');
                var splitPolicy = splitPasswordAndPolicy[0].Split(' ');
                var splitOccurances = splitPolicy[0].Split('-');

                var password = splitPasswordAndPolicy[1];
                var lowerOccurrances = int.Parse(splitOccurances[0]);
                var higherOccurrances = int.Parse(splitOccurances[1]);
                var letter = splitPolicy[1].ToCharArray()[0];

                var letterCount = password.ToCharArray().Count(x => x == letter);
                if (lowerOccurrances <= letterCount && higherOccurrances >= letterCount)
                {
                    ++validPasswordCount;
                }
            }

            Console.WriteLine($"Answer is: {validPasswordCount}");
        }

        public void Solve2(string[] data)
        {
            var validPasswordCount = 0;
            foreach (var passwordAndPolicy in data)
            {
                var splitPasswordAndPolicy = passwordAndPolicy.Split(':');
                var splitPolicy = splitPasswordAndPolicy[0].Split(' ');
                var splitOccurances = splitPolicy[0].Split('-');

                var password = splitPasswordAndPolicy[1].Trim().ToCharArray();
                var lowerOccurrances = int.Parse(splitOccurances[0]);
                var higherOccurrances = int.Parse(splitOccurances[1]);
                var letter = splitPolicy[1].ToCharArray()[0];

                var firstLetter = password[lowerOccurrances-1];
                var secondLetter = password[higherOccurrances-1];
                if ((firstLetter == letter || secondLetter == letter) && firstLetter != secondLetter)
                {
                    ++validPasswordCount;
                }
            }

            Console.WriteLine($"Answer is: {validPasswordCount}");
        }
    }
}