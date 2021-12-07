using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day7
    {
        private string[] _data;

        public Day7()
        {
            _data = PuzzleInput.FetchStringArray(7);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new[] { 16,1,2,0,4,2,7,1,2,14 });
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Solve(_data.First().Split(",").Select(x => int.Parse(x)).ToArray());
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            Solve2(new[] { 16,1,2,0,4,2,7,1,2,14 });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data.First().Split(",").Select(x => int.Parse(x)).ToArray());
            Console.WriteLine();
        }

        private void Solve(int[] data)
        {
            var cheapestFuel = int.MaxValue;
            var positions = data.OrderBy(x => x);
            for (var i=0; i<positions.Last(); ++i)
            {
                var fuel = positions.Sum(x => Math.Abs(x-i));
                cheapestFuel = Math.Min(cheapestFuel, fuel);
            }

            Console.WriteLine(cheapestFuel);
        }

        private void Solve2(int[] data)
        {
            var cheapestFuel = int.MaxValue;
            var positions = data.OrderBy(x => x);
            for (var i=0; i<positions.Last(); ++i)
            {
                var fuel = positions.Sum(x => Enumerable.Range(1, Math.Abs(x-i)).Sum(y => y));
                cheapestFuel = Math.Min(cheapestFuel, fuel);
            }

            Console.WriteLine(cheapestFuel);
        }
    }
}