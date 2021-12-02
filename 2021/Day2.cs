using System;

using AdventOfCode;

namespace AdventOfCode
{
    public class Day2
    {
        private string[] _data;

        public Day2()
        {
            _data = PuzzleInput.FetchStringArray(2);
        }
        
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            Solve(new [] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });
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
            Solve2(new [] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" });
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
            var horizontalPosition = 0;
            var depth = 0;
            foreach (var instruction in data)
            {
                var tokens = instruction.Split(" ");
                if (tokens[0].Equals("forward"))
                {
                    horizontalPosition += int.Parse(tokens[1]);
                }
                else if (tokens[0].Equals("up"))
                {
                    depth -= int.Parse(tokens[1]);
                }
                else if (tokens[0].Equals("down"))
                {
                    depth += int.Parse(tokens[1]);
                }
            }

            Console.WriteLine(horizontalPosition*depth);
        }

        public void Solve2(string[] data)
        {
            var horizontalPosition = 0;
            var depth = 0;
            var aim = 0;
            foreach (var instruction in data)
            {
                var tokens = instruction.Split(" ");
                var value = int.Parse(tokens[1]);
                if (tokens[0].Equals("forward"))
                {
                    horizontalPosition += value;
                    depth += aim * value;
                }
                else if (tokens[0].Equals("up"))
                {
                    aim -= value;
                }
                else if (tokens[0].Equals("down"))
                {
                    aim += value;
                }
            }

            Console.WriteLine(horizontalPosition*depth);
        }
    }
}