using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day11
    {
        private string[] _data;

        public Day11()
        {
            _data = PuzzleInput.FetchStringArray(11);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one example:");
            Solve(new[] { "5483143223", "2745854711", "5264556173", "6141336146", "6357385478", "4167524645", "2176841721", "6882881134", "4846848554", "5283751526" }, 100, false);
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Solve(_data, 100, false);
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two example:");
            Solve(new[] { "5483143223", "2745854711", "5264556173", "6141336146", "6357385478", "4167524645", "2176841721", "6882881134", "4846848554", "5283751526" }, 0, true);
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve(_data, 0, true);
            Console.WriteLine();
        }

        private void Solve(string[] data, int steps, bool infinite)
        {
            var width = data.Length;
            var height = data[0].Length;
            var map = new int[width, height];
            var flashCount = 0;

            for (var x = 0; x < width; ++x)
            {
                for (var y = 0; y < height; ++y)
                {
                    map[x,y] = data[x][y]-48;
                }
            }

            while (steps-- > 0 || infinite)
            {
                int maxFlash = width*height;
                for (var x = 0; x < width; ++x)
                {
                    for (var y = 0; y < height; ++y)
                    {
                        IncrementEnergy(ref map, x, y, width, height);

                    }
                }
                for (var x = 0; x < width; ++x)
                {
                    for (var y = 0; y < height; ++y)
                    {
                        if (map[x,y] > 9)
                        {
                            map[x,y] = 0;
                            ++flashCount;
                            --maxFlash;
                        }
                    }
                }

                if (maxFlash == 0)
                    break;
            }

            Console.WriteLine(flashCount);

            if (infinite)
            {
                Console.WriteLine(Math.Abs(steps));
            }
        }

        private void IncrementEnergy(ref int[,] map, int x, int y, int width, int height)
        {
            if (++map[x,y] == 10)
            {
                for (var i=Math.Max(x-1, 0); i<=Math.Min(x+1, width-1); ++i)
                {
                    for (var j=Math.Max(y-1, 0); j<=Math.Min(y+1, height-1); ++j)
                    {
                        if (i != x || j != y)
                        {
                            IncrementEnergy(ref map, i, j, width, height);
                        }
                    }
                }
            }
        }
    }
}