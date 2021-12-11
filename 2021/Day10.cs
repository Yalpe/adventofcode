using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day10
    {
        private string[] _data;

        public Day10()
        {
            _data = PuzzleInput.FetchStringArray(10);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one example:");
            Solve(new[] { "[({(<(())[]>[[{[]{<()<>>", "[(()[<>])]({[<{<<[]>>(", "{([(<{}[<>[]}>{[]{[(<()>", "(((({<>}<{<{<>}{[]{[]{}", "[[<[([]))<([[{}[[()]]]", "[{[{({}]{}}([{[{{{}}([]", "{<[[]]>}<{[{[{[]{()[[[]", "[<(<(<(<{}))><([]([]()", "<{([([[(<>()){}]>(<<{{", "<{([{{}}[<[[[<>{}]]]>[]]" });
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
            var autoCompleteChunkScores = new Dictionary<char, long>() { { '>', 4 }, { ']', 2 }, { '}', 3 }, { ')', 1 } };
            var illegalChunkScores = new Dictionary<char, int>() { { '>', 25137 }, { ']', 57 }, { '}', 1197 }, { ')', 3 } };
            var openToCloseMap = new Dictionary<char, char>() { { '<', '>' }, { '[', ']' }, { '{', '}' }, { '(', ')' } };
            var corruptedScore = 0;
            var lineScores = new List<long>();
            foreach (var line in data)
            {
                var corrupted = false;
                var chunks = new Stack<char>();
                foreach (var chunk in line)
                {
                    if (chunk == '<' || chunk == '(' || chunk == '[' || chunk == '{')
                    {
                        chunks.Push(chunk);
                    }
                    else if (chunk == '>' || chunk == ')' || chunk == ']' || chunk == '}')
                    {
                        if (chunk != openToCloseMap[chunks.Pop()])
                        {
                            corrupted = true;
                            corruptedScore += illegalChunkScores[chunk];
                            break;
                        }
                    }
                }
                
                if (!corrupted)
                {
                    var autoCompleteScore = 0L;
                    foreach (var chunk in chunks)
                    {
                        autoCompleteScore = autoCompleteScore * 5 + autoCompleteChunkScores[openToCloseMap[chunk]];
                    }

                    lineScores.Add(autoCompleteScore);
                }
            }

            Console.WriteLine(corruptedScore);
            Console.WriteLine(lineScores.OrderBy(x => x).Skip((lineScores.Count - 1)/2).First());
        }
    }
}