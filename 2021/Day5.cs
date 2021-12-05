using System;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day5
    {
        private string[] _data;

        public Day5()
        {
            _data = PuzzleInput.FetchStringArray(5);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new[] { "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4", "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2" });
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
            Solve2(new[] { "0,9 -> 5,9", "8,0 -> 0,8", "9,4 -> 3,4", "2,2 -> 2,1", "7,0 -> 7,4", "6,4 -> 2,0", "0,9 -> 2,9", "3,4 -> 1,4", "0,0 -> 8,8", "5,5 -> 8,2" });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data);
            Console.WriteLine();
        }

        private void Solve(string[] data)
        {
            const int arraySize = 1000;
            var pointMatrix = new int[arraySize,arraySize];

            foreach (var line in data)
            {
                var rawPoints = line.Split(" -> ");
                var coords1 = rawPoints[0].Split(",").Select(x => int.Parse(x)).ToArray();
                var coords2 = rawPoints[1].Split(",").Select(x => int.Parse(x)).ToArray();

                if (coords1[0] == coords2[0])
                {
                    for (var y = Math.Min(coords1[1], coords2[1]); y <= Math.Max(coords1[1], coords2[1]); ++y)
                    {
                        pointMatrix[coords1[0], y]++;
                    }
                }

                if (coords1[1] == coords2[1])
                {
                    for (var x = Math.Min(coords1[0], coords2[0]); x <= Math.Max(coords1[0], coords2[0]); ++x)
                    {
                        pointMatrix[x, coords1[1]]++;
                    }
                }
            }

            var overlaps = 0;
            for (var x=0; x<arraySize; ++x)
            {
                for (var y=0; y<arraySize; ++y)
                {
                    overlaps = pointMatrix[x,y] > 1 ? overlaps + 1 : overlaps;
                }
            }
            Console.Write(overlaps);
        }

        private void Solve2(string[] data)
        {
            const int arraySize = 1000;
            var pointMatrix = new int[arraySize,arraySize];

            foreach (var line in data)
            {
                var rawPoints = line.Split(" -> ");
                var coords1 = rawPoints[0].Split(",").Select(x => int.Parse(x)).ToArray();
                var coords2 = rawPoints[1].Split(",").Select(x => int.Parse(x)).ToArray();

                if (coords1[0] == coords2[0])
                {
                    for (var y = Math.Min(coords1[1], coords2[1]); y <= Math.Max(coords1[1], coords2[1]); ++y)
                    {
                        pointMatrix[coords1[0], y]++;
                    }
                }
                else if (coords1[1] == coords2[1])
                {
                    for (var x = Math.Min(coords1[0], coords2[0]); x <= Math.Max(coords1[0], coords2[0]); ++x)
                    {
                        pointMatrix[x, coords1[1]]++;
                    }
                }
                else
                {
                    var dx = coords1[0] > coords2[0] ? -1 : 1;
                    var dy = coords1[1] > coords2[1] ? -1 : 1;
                    var length = Math.Max(coords1[0], coords2[0]) - Math.Min(coords1[0], coords2[0]);
                    while (length-- >= 0)
                    {
                        pointMatrix[coords1[0], coords1[1]]++;
                        coords1[0] += dx;
                        coords1[1] += dy;
                    }
                }
            }

            var overlaps = 0;
            for (var x=0; x<arraySize; ++x)
            {
                for (var y=0; y<arraySize; ++y)
                {
                    overlaps = pointMatrix[x,y] > 1 ? overlaps + 1 : overlaps;
                }
            }
            Console.Write(overlaps);
        }
    }
}