using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public class Day4
    {
        private string[] _data;

        public Day4()
        {
            _data = PuzzleInput.FetchStringArray(4);
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new [] { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1", "", "22 13 17 11  0"," 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19", "", " 3 15  0  2 22", " 9 18 13 17  5", "19  8  7 25 23", "20 11 10 24  4", "14 21 16 12  6", "", "14 21 17 24  4", "10 16 15  9 19", "18  8 23 26 20", "22 11 13  6  5", " 2  0 12  3  7" });
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
            Solve2(new [] { "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1", "", "22 13 17 11  0"," 8  2 23  4 24", "21  9 14 16  7", " 6 10  3 18  5", " 1 12 20 15 19", "", " 3 15  0  2 22", " 9 18 13 17  5", "19  8  7 25 23", "20 11 10 24  4", "14 21 16 12  6", "", "14 21 17 24  4", "10 16 15  9 19", "18  8 23 26 20", "22 11 13  6  5", " 2  0 12  3  7" });
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");
            Solve2(_data);
            Console.WriteLine();
        }

        private class Board
        {
            public bool[,] Markers = new bool[5, 5];

            public int[,] Numbers = new int[5, 5];

            public bool IsWinner()
            {
                for (var i=0; i<5; ++i)
                {
                    var isMarked = true;
                    for (var j=0; j<5; ++j)
                    {
                        isMarked = isMarked && this.Markers[i,j];
                        if (!isMarked) break;
                    }
                    if (isMarked) return true;
                }
                
                for (var j=0; j<5; ++j)
                {
                    var isMarked = true;
                    for (var i=0; i<5; ++i)
                    {
                        isMarked = isMarked && this.Markers[i,j];
                        if (!isMarked) break;
                    }
                    if (isMarked) return true;
                }

                /*if ((this.Markers[0,0] && this.Markers[1,1] && this.Markers[2,2] && this.Markers[3,3] && this.Markers[4,4]) ||
                    (this.Markers[0,4] && this.Markers[1,3] && this.Markers[2,2] && this.Markers[3,1] && this.Markers[4,0]))
                {
                    return true;
                }*/

                return false;
            }
        }

        public void Solve(string[] data)
        {
            var numbers = new Queue<int>(data[0].Split(",").Select(x => int.Parse(x)));
            var boards = new List<Board>();
            var rowIndex = 5;
            foreach(var line in data.Skip(1).Where(x => !string.IsNullOrEmpty(x)))
            {
                if (rowIndex == 5)
                {
                    boards.Add(new Board());
                    rowIndex = 0;
                }

                var board = boards.Last();
                var columnIndex = 0;
                foreach(var number in line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x =>int.Parse(x)))
                {
                    board.Numbers[rowIndex, columnIndex++] = number;
                }

                ++rowIndex;
            }

            while (numbers.Count > 0)
            {
                var number = numbers.Dequeue();
                foreach (var board in boards)
                {
                    for (var i=0; i<5; ++i)
                    {
                        var marked = false;
                        for (var j=0; j<5; ++j)
                        {
                            if (board.Numbers[i,j] == number)
                            {
                                marked = true;
                                board.Markers[i,j] = true;
                                break;
                            }
                        }
                        if (marked) break;
                    }
                }

                var winningBoard = boards.FirstOrDefault(x => x.IsWinner());
                if (winningBoard != null)
                {
                    var sum = 0;
                    for (var i=0; i<5; ++i)
                    {
                        for (var j=0; j<5; ++j)
                        {
                            if (!winningBoard.Markers[i,j])
                            {
                                sum += winningBoard.Numbers[i,j];
                            }
                        }
                    }

                    Console.WriteLine(number * sum);
                    break;
                }
            }
        }

        public void Solve2(string[] data)
        {
            var numbers = new Queue<int>(data[0].Split(",").Select(x => int.Parse(x)));
            var boards = new List<Board>();
            var rowIndex = 5;
            foreach(var line in data.Skip(1).Where(x => !string.IsNullOrEmpty(x)))
            {
                if (rowIndex == 5)
                {
                    boards.Add(new Board());
                    rowIndex = 0;
                }

                var board = boards.Last();
                var columnIndex = 0;
                foreach(var number in line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(x =>int.Parse(x)))
                {
                    board.Numbers[rowIndex, columnIndex++] = number;
                }

                ++rowIndex;
            }

            while (numbers.Count > 0)
            {
                var number = numbers.Dequeue();
                foreach (var board in boards)
                {
                    for (var i=0; i<5; ++i)
                    {
                        var marked = false;
                        for (var j=0; j<5; ++j)
                        {
                            if (board.Numbers[i,j] == number)
                            {
                                marked = true;
                                board.Markers[i,j] = true;
                                break;
                            }
                        }
                        if (marked) break;
                    }
                }

                if (boards.Count > 1)
                {
                    boards = boards.Where(x => !x.IsWinner()).ToList();
                }
                
                var winningBoard = boards.FirstOrDefault(x => x.IsWinner());
                if (winningBoard != null)
                {
                    var sum = 0;
                    for (var i=0; i<5; ++i)
                    {
                        for (var j=0; j<5; ++j)
                        {
                            if (!winningBoard.Markers[i,j])
                            {
                                sum += winningBoard.Numbers[i,j];
                            }
                        }
                    }

                    Console.WriteLine(number * sum);
                    break;
                }
            }
        }
    }
}