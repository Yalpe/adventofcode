using System;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day3
    {
        public Day3()
        {
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var trees = Solve(new[] { 
                "..##.......".ToCharArray(),
                "#...#...#..".ToCharArray(),
                ".#....#..#.".ToCharArray(),
                "..#.#...#.#".ToCharArray(),
                ".#...##..#.".ToCharArray(),
                "..#.##.....".ToCharArray(),
                ".#.#.#....#".ToCharArray(),
                ".#........#".ToCharArray(),
                "#.##...#...".ToCharArray(),
                "#...##....#".ToCharArray(),
                ".#..#...#.#".ToCharArray()
            }, 3, 1);
            Console.WriteLine($"Answer is: {trees}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var trees = Solve(PuzzleInput.FetchGrid(3), 3, 1);
            Console.WriteLine($"Answer is: {trees}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var trees = Solve2(new[] { 
                "..##.......".ToCharArray(),
                "#...#...#..".ToCharArray(),
                ".#....#..#.".ToCharArray(),
                "..#.#...#.#".ToCharArray(),
                ".#...##..#.".ToCharArray(),
                "..#.##.....".ToCharArray(),
                ".#.#.#....#".ToCharArray(),
                ".#........#".ToCharArray(),
                "#.##...#...".ToCharArray(),
                "#...##....#".ToCharArray(),
                ".#..#...#.#".ToCharArray()
            });
            Console.WriteLine($"Answer is: {trees}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            var trees = Solve2(PuzzleInput.FetchGrid(3));
            Console.WriteLine($"Answer is: {trees}");
            Console.WriteLine();
        }

        public int Solve(char[][] grid, int right, int down)
        {
            var i = down;
            var j = 0;
            var trees = 0;
            while (i < grid.Length)
            {
                var row = grid[i];
                j += right;
                if (j >= row.Length)
                    j -= row.Length;
                if (row[j] == '#')
                    ++trees;
                i += down;
            }
            
            return trees;
        }

        public long Solve2(char[][] grid)
        {
            var rights = new[] { 1, 3, 5, 7, 1 };
            var downs = new[] { 1, 1, 1, 1, 2 };
            var result = 1L;
            for (var i = 0; i < rights.Length; ++i)
            {
                result *= Solve(grid, rights[i], downs[i]);
            }

            return result;
        }
    }
}