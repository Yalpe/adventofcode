using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day3
    {
        private string[] _data;

        public Day3()
        {
            _data = PuzzleInput.FetchStringArray(3);
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new [] { "00100", "11110", "10110","10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" });
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
            Solve2(new [] { "00100", "11110", "10110","10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data);
            Console.WriteLine();
        }

        public void Solve(string[] data)
        {
            var bitcount = data[0].Length;
            var zeros = new uint[bitcount];
            var ones = new uint[bitcount];

            foreach (var bitfield in data)
            {
                for (var i=0; i < bitcount; ++i)
                {
                    if (bitfield[i] == '0')
                        ++zeros[i];
                    else
                        ++ones[i];
                }
            }

            var gamma = 0;
            var epsilon = 0;
            for (var i=0; i<bitcount; ++i)
            {
                if (zeros[i] < ones[i])
                    gamma |= 1 << (bitcount - i - 1);
                else
                    epsilon |= 1 << (bitcount - i - 1);
            }

            Console.WriteLine(gamma * epsilon);
        }

        public void Solve2(string[] data)
        {
            var bitcount = data[0].Length;
            var numbers = data.Select(x => Convert.ToUInt32(x, 2)).ToList();

            var oxygenator = MatchCriteria(numbers, 0, bitcount, false);
            var scrubber = MatchCriteria(numbers, 0, bitcount, true);

            Console.WriteLine(oxygenator * scrubber);
        }

        private uint MatchCriteria(List<uint> numbers, int index, int bitcount, bool fewer)
        {
            var subset = new List<uint>();
            var zeros = 0;
            var ones = 0;

            foreach (var number in numbers)
            {
                var mask = 1U << (bitcount - index - 1);
                if ((number & mask) == 0)
                    ++zeros;
                else
                    ++ones;
            }

            foreach (var number in numbers)
            {
                var test = zeros <= ones ? number : ~number;
                if (fewer) test = ~test;

                var mask = 1U << (bitcount - index - 1);
                if ((test & mask) > 0)
                    subset.Add(number);
            }

            if (subset.Count == 1)
                return subset[0];
            
            return MatchCriteria(subset, index+1, bitcount, fewer);
        }
    }
}