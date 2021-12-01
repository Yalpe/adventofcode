using System;

using AdventOfCode;

namespace AdventOfCode
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
            Solve(new [] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 });
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
            Solve2(new [] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 });
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
            var totalIncrements = 0;
            for (var i=1; i<data.Length; ++i)
            {
                if (data[i] > data[i-1])
                    ++totalIncrements;
            }

            Console.WriteLine(totalIncrements);
        }

        public void Solve2(int[] data)
        {
            var totalIncrements = 0;
            for (var i=3; i<data.Length; ++i)
            {
                var firstWindowSum = data[i-1] + data[i-2] + data[i-3];
                var secondWindowSum = data[i] + data[i-1] + data[i-2];
                if (secondWindowSum > firstWindowSum)
                    ++totalIncrements;
            }

            Console.WriteLine(totalIncrements);
        }
    }
}