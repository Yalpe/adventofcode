using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day6
    {
        private string[] _data;

        public Day6()
        {
            _data = PuzzleInput.FetchStringArray(6);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new[] { 3,4,3,1,2 }, 18);
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Solve(_data.First().Split(",").Select(x => int.Parse(x)).ToArray(), 80);
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            Solve(new[] { 3,4,3,1,2 }, 256);
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve(_data.First().Split(",").Select(x => int.Parse(x)).ToArray(), 256);
            Console.WriteLine();
        }

        private void Solve(int[] data, int days)
        {
            var fishByAge = new List<long>(9) { 0,0,0,0,0,0,0,0,0};
            
            foreach (var age in data)
            {
                ++fishByAge[age];
            }

            for (var i=0; i<days; ++i)
            {
                var newFish = fishByAge[0];
                fishByAge.RemoveAt(0);
                fishByAge.Add(newFish);
                fishByAge[6] += newFish;
            }
            
            Console.WriteLine(fishByAge.Sum(x => x));
        }
    }
}