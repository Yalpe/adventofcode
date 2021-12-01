using System;
using System.Linq;
using System.Collections.Generic;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day9
    {
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var sequence = new[] {
                35L,
                20L,
                15L,
                25L,
                47L,
                40L,
                62L,
                55L,
                65L,
                95L,
                102L,
                117L,
                150L,
                182L,
                127L,
                219L,
                299L,
                277L,
                309L,
                576L
            };
            Console.WriteLine($"Answer is: {GetInvalidNumber(sequence, 5)}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            Console.WriteLine($"Answer is: {GetInvalidNumber(PuzzleInput.FetchLongArray(9), 25)}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var sequence = new[] {
                35L,
                20L,
                15L,
                25L,
                47L,
                40L,
                62L,
                55L,
                65L,
                95L,
                102L,
                117L,
                150L,
                182L,
                127L,
                219L,
                299L,
                277L,
                309L,
                576L
            };
            Console.WriteLine($"Answer is: {FindEncryptionWeakness(sequence, 127)}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Console.WriteLine($"Answer is: {FindEncryptionWeakness(PuzzleInput.FetchLongArray(9), 1492208709)}");
            Console.WriteLine();
        }

        public long GetInvalidNumber(long[] sequence, int preambleLength)
        {
            for (var i = preambleLength; i < sequence.Length; ++i)
            {
                var preamble = new List<long>(sequence.Skip(i - preambleLength).Take(preambleLength));
                if (!IsValid(preamble, sequence[i]))
                {
                    return sequence[i];
                }
            }

            return -1;
        }

        public bool IsValid(List<long> preamble, long number)
        {
            for (var i = 0; i < preamble.Count; ++i)
            {
                for (var j = i + 1; j < preamble.Count; ++j)
                {
                    if (preamble[i] + preamble[j] == number)
                        return true;
                }
            }

            return false;
        }

        public long FindEncryptionWeakness(long[] sequence, long invalidNumber)
        {
            var contiguousSet = FindContiguousSet(sequence, invalidNumber).OrderBy(x => x).ToList();

            return contiguousSet.First() + contiguousSet.Last();
        }

        public List<long> FindContiguousSet(long[] sequence, long invalidNumber)
        {
            for (var i = 0; i < sequence.Length; ++i)
            {
                var sum = sequence[i];
                for (var j = i + 1; j < sequence.Length; ++j)
                {
                    sum += sequence[j];
                    if (sum == invalidNumber)
                    {
                        return sequence.Skip(i).Take(j - i + 1).ToList();
                    }

                    if (sum > invalidNumber)
                    {
                        break;
                    }
                }
            }

            return null;
        }
    }
}