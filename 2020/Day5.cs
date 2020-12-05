using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day5
    {
        public Day5()
        {
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var seatId = GetHighestSeadId(new[]
            {
                "FBFBBFFRLR",
                "BFFFBBFRRR",
                "FFFBBBFRRR",
                "BBFFBBFRLL"
            });
            Console.WriteLine($"Answer is: {seatId}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var seatId = GetHighestSeadId(PuzzleInput.FetchStringArray(5));
            Console.WriteLine($"Answer is: {seatId}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            var seatId = GetSeadId(PuzzleInput.FetchStringArray(5));
            Console.WriteLine($"Answer is: {seatId}");
            Console.WriteLine();
        }

        public int GetHighestSeadId(string[] data)
        {
            return GetSeats(data).Max(x => x.Item1 * 8 + x.Item2);
        }

        public int GetSeadId(string[] data)
        {
            var seatsByRow = GetSeats(data).GroupBy(x => x.Item1).ToDictionary(x => x.Key, x => x.Select(y => y.Item2).OrderBy(y => y).ToArray());
            var firstRow = seatsByRow.Keys.Min();
            var lastRow = seatsByRow.Keys.Max();
            for (var i = firstRow + 1; i < lastRow - 2; ++i)
            {
                var columns = seatsByRow[i];
                for (var j = 1; j < columns.Count() - 2; ++j)
                {
                    if (columns[j] - columns[j-1] > 1)
                    {
                        return i * 8 + (j-1);
                    }
                    
                    if (columns[j+1] - columns[j] > 1)
                    {
                        return i * 8 + (j+1);
                    }
                }
            }

            return 0;
        }

        public IList<Tuple<int, int>> GetSeats(string[] data)
        {
            var seatIds = new List<Tuple<int, int>>();
            foreach (var seat in data)
            {
                var rowLow = 0;
                var rowHigh = 127;
                var columnLow = 0;
                var columnHigh = 7;
                foreach (var letter in seat)
                {
                    if (letter == 'F')
                    {
                        rowHigh = rowLow + ((rowHigh - rowLow) / 2);
                    }
                    else if (letter == 'B')
                    {
                        rowLow = rowHigh - ((rowHigh - rowLow) / 2);
                    }
                    if (letter == 'L')
                    {
                        columnHigh = columnLow + ((columnHigh - columnLow) / 2);
                    }
                    else if (letter == 'R')
                    {
                        columnLow = columnHigh - ((columnHigh - columnLow) / 2);
                    }
                }

                seatIds.Add(new Tuple<int, int>(rowLow, columnLow));
            }

            return seatIds;
        }
    }
}