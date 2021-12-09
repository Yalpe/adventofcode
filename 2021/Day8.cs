using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode;

namespace AdventOfCode
{
    public class Day8
    {
        private string[] _data;

        public Day8()
        {
            _data = PuzzleInput.FetchStringArray(8);
        }

        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one and two examples:");
            Solve(new[] { "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf" });
            Solve(new[]
                {
                    "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                    "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                    "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                    "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                    "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                    "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                    "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                    "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                    "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                    "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
                });
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one and two:");
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
            var uniqueSignalsCount = 0;
            var outputSum = 0;
            foreach (var signalsAndOutputData in data)
            {
                var signalsAndOutput = signalsAndOutputData.Split(" | ");
                var signals = signalsAndOutput[0].Split(" ").Select(x => String.Concat(x.OrderBy(c => c))).OrderBy(x => x.Length).ToList();
                var outputs = signalsAndOutput[1].Split(" ").Select(x => String.Concat(x.OrderBy(c => c))).ToList();

                var signalMap = new List<string>() { "", "", "", "", "", "", "", "", "", "" };
                signalMap[1] = signals[0];
                signalMap[4] = signals[2];
                signalMap[7] = signals[1];
                signalMap[8] = signals[9];
                signalMap[9] = signals.First(x => x.Length == 6 && signalMap[4].All(x.Contains));
                signalMap[2] = signals.First(x => x.Length == 5 && !x.All(signalMap[9].Contains));
                signalMap[3] = signals.First(x => x.Length == 5 && x.All(signalMap[9].Contains) && signalMap[1].All(x.Contains));
                signalMap[5] = signals.First(x => x.Length == 5 && !signalMap.Contains(x));
                signalMap[6] = signals.First(x => x.Length == 6 && x != signalMap[9] && x.All(signalMap[8].Contains) && signalMap[5].All(x.Contains));
                signalMap[0] = signals.First(x => !signalMap.Contains(x));

                uniqueSignalsCount += outputs.Count(x => x.Length == 2 || x.Length == 3 || x.Length == 4 || x.Length == 7);

                outputSum += int.Parse(String.Concat(outputs.Select(x => signalMap.IndexOf(x))));
            }

            Console.WriteLine(uniqueSignalsCount);
            Console.WriteLine(outputSum);
        }
    }
}