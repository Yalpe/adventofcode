using System;
using System.Collections.Generic;
using System.Linq;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day10
    {
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var ratings = new[] {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };
            Console.WriteLine($"Answer is: {GetJoltDifference(ratings)}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Console.WriteLine($"Answer is: {GetJoltDifference(PuzzleInput.FetchIntArray(10))}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var ratings = new[] {
                16,
                10,
                15,
                5,
                1,
                11,
                7,
                19,
                6,
                12,
                4
            };
            Console.WriteLine($"Answer is: {GetCombinations(ratings)}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Console.WriteLine($"Answer is: {GetCombinations(PuzzleInput.FetchIntArray(10))}");
            Console.WriteLine();
        }

        public int GetJoltDifference(int[] data)
        {
            var joltDifferences = new int[4];
            var joltRatings = data.OrderBy(x => x).ToList();
            var currentRating = 0;

            joltRatings.Add(joltRatings.Last() + 3);

            foreach (var joltRating in joltRatings)
            {
                ++joltDifferences[joltRating - currentRating];
                currentRating = joltRating;
            }

            return joltDifferences[1] * joltDifferences[3];
        }

        public long GetCombinations(int[] data)
        {
            var joltDifferences = new int[4];
            var joltRatings = data.OrderBy(x => x).ToList();
            var currentRating = 0;

            foreach (var joltRating in joltRatings)
            {
                ++joltDifferences[joltRating - currentRating];
                currentRating = joltRating;
            }

            return (long)Math.Pow(2, joltDifferences[1] - joltDifferences[3]) * (long)Math.Pow(7, joltDifferences[3]);
        }
    }
}