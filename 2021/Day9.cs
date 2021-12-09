using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day9
    {
        private string[] _data;

        public Day9()
        {
            _data = PuzzleInput.FetchStringArray(9);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one example:");
            Solve(new[] { "2199943210", "3987894921", "9856789892", "8767896789", "9899965678" });
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
        }
        
        public void SolvePartTwo()
        {
        }

        private void Solve(string[] data)
        {
            var width = data.Length;
            var height = data[0].Length;
            var map = new int[width, height];
            for (var x = 0; x < width; ++x)
            {
                for (var y = 0; y < height; ++y)
                {
                    map[x,y] = ((int)data[x][y])-48;
                }
            }

            var riskLevel = 0;
            var bassinSizes = new List<int>();
            for (var x = 0; x < width; ++x)
            {
                for (var y = 0; y < height; ++y)
                {
                    var lowPoint = true;
                    if (x > 0) lowPoint &= map[x-1, y] > map[x, y]; // left
                    if (x < width - 1) lowPoint &= map[x+1, y] > map[x, y]; // right
                    if (y > 0) lowPoint &= map[x, y-1] > map[x, y]; // top
                    if (y < height - 1) lowPoint &= map[x, y+1] > map[x, y]; // bottom
                    if (lowPoint)
                    {
                        riskLevel += 1 + map[x, y];
                        var bassinCoords = new HashSet<Tuple<int, int>>();
                        FindBassin(bassinCoords, new Tuple<int, int>(x, y), map, width, height);
                        bassinSizes.Add(bassinCoords.Count);
                    }
                }
            }

            Console.WriteLine(riskLevel);
            Console.WriteLine(bassinSizes.OrderByDescending(x => x).Take(3).Aggregate(1, (x,y) => x * y));
        }

        public void FindBassin(HashSet<Tuple<int, int>> bassinCoords, Tuple<int, int> coord, int[,] map, int width, int height)
        {
            if (!bassinCoords.Add(coord))
            {
                return;
            }

            if (coord.Item1 > 0 && map[coord.Item1-1, coord.Item2] < 9)
            {
                FindBassin(bassinCoords, new Tuple<int, int>(coord.Item1-1, coord.Item2), map, width, height);
            }
            
            if (coord.Item1 < width - 1 && map[coord.Item1+1, coord.Item2] < 9)
            {
                FindBassin(bassinCoords, new Tuple<int, int>(coord.Item1+1, coord.Item2), map, width, height);
            }
            
            if (coord.Item2 > 0 && map[coord.Item1, coord.Item2-1] < 9)
            {
                FindBassin(bassinCoords, new Tuple<int, int>(coord.Item1, coord.Item2-1), map, width, height);
            }
            
            if (coord.Item2 < height - 1 && map[coord.Item1, coord.Item2+1] < 9)
            {
                FindBassin(bassinCoords, new Tuple<int, int>(coord.Item1, coord.Item2+1), map, width, height);
            }
        }
    }
}