using System;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day1
    {
        private int[] _data;

        public Day1()
        {
            _data = PuzzleInput.FetchIntArray(1);
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new[] { 1721, 979, 366, 299, 675, 1456 });
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
            Solve2(new[] { 1721, 979, 366, 299, 675, 1456 });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data);
            Console.WriteLine();
        }

        public void Solve(int[] data)
        {
            for (var i = 0; i < data.Length; ++i)
            {
                for (var j = i + 1; j < data.Length; ++j)
                {
                    if (data[i] + data[j] == 2020)
                    {
                        Console.WriteLine($"Answer is {data[i]*data[j]}");
                        return;
                    }
                }
            }
        }

        public void Solve2(int[] data)
        {
            for (var i = 0; i < data.Length; ++i)
            {
                for (var j = i + 1; j < data.Length; ++j)
                {
                    for (var k = j + 1; k < data.Length; ++k)
                    {
                        if (data[i] + data[j] + data[k] == 2020)
                        {
                            Console.WriteLine($"Answer is {data[i]*data[j]*data[k]}");
                            return;
                        }
                    }
                }
            }
        }
    }
}