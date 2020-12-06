using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day6
    {
        public Day6()
        {
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var sum = GetSum(new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            });
            Console.WriteLine($"Answer is: {sum}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var sum = GetSum(PuzzleInput.FetchStringArrayRaw(6));
            Console.WriteLine($"Answer is: {sum}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var sum = GetSumEveryone(new[]
            {
                "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            });
            Console.WriteLine($"Answer is: {sum}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            var sum = GetSumEveryone(PuzzleInput.FetchStringArrayRaw(6));
            Console.WriteLine($"Answer is: {sum}");
            Console.WriteLine();
        }

        public int GetSum(string[] data)
        {
            return GetAnswers(data).Select(x => new HashSet<char>(x.SelectMany(y => y))).Sum(x => x.Count);
        }

        public int GetSumEveryone(string[] data)
        {
            var sum = 0;
            var answers = GetAnswers(data);
            foreach (var group in answers)
            {
                var intersection = new HashSet<char>(group[0]);
                for (var i = 1; i < group.Count; ++i)
                {
                    intersection.IntersectWith(group[i]);
                }
                
                sum += intersection.Count;
            }

            return sum;
        }

        public List<List<List<char>>> GetAnswers(string[] data)
        {
            var i = 0;
            var groups = new List<List<List<char>>>();
            while (i < data.Length)
            {
                var group = new List<List<char>>();
                while (i < data.Length && !string.IsNullOrEmpty(data[i]))
                {
                    var answers = new List<char>();
                    foreach (var keyValue in data[i])
                    {
                        answers.Add(keyValue);
                    }

                    group.Add(answers);

                    ++i;
                }

                groups.Add(group);

                ++i;
            }

            return groups;
        }
    }
}