using System;
using System.Linq;
using System.Collections.Generic;

using AdventOfCode;

namespace AdventOfCode2020
{
    public class Day8
    {
        public void SolveExamplesPartOne()
        {
            Console.WriteLine("Part one examples:");
            var console = new GameConsole(new[] {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            });            
            Console.WriteLine($"Answer is: {this.GetAccumulatorAtRepeat(console)}");
            Console.WriteLine();
        }
    
        public void SolvePartOne()
        {
            Console.WriteLine("Part one:");
            var console = new GameConsole(PuzzleInput.FetchStringArray(8));            
            Console.WriteLine($"Answer is: {this.GetAccumulatorAtRepeat(console)}");
            Console.WriteLine();
        }
        
        public void SolveExamplesPartTwo()
        {
            Console.WriteLine("Part two examples:");
            var gameConsole = new GameConsole(new[] {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            });            
            Console.WriteLine($"Answer is: {this.TryFixingIt(gameConsole)}");
            Console.WriteLine();
        }
        
        public void SolvePartTwo()
        {
            Console.WriteLine("Part two:");   
            var gameConsole = new GameConsole(PuzzleInput.FetchStringArray(8));
            Console.WriteLine($"Answer is: {this.TryFixingIt(gameConsole)}");
            Console.WriteLine();
        }

        public int GetAccumulatorAtRepeat(GameConsole gameConsole)
        {
            var executedInstructions = new HashSet<int>();

            while (executedInstructions.Add(gameConsole.InstructionPointer))
            {
                gameConsole.Tick();
            }

            return gameConsole.Accumulator;
        }

        public int TryFixingIt(GameConsole gameConsole)
        {
            var nbSkipped = 0;
            var nbIterations = 1;
            while (--nbIterations >= 0)
            {
                if (gameConsole.IsTerminated)
                {
                    break;
                }

                if (nbIterations == 0)
                {
                    gameConsole.ParseCode();
                    var replacedInstruction = gameConsole.Instructions.Where(x => x is GameConsole.Jmp || x is GameConsole.Nop).Skip(nbSkipped++).First();
                    var index = gameConsole.Instructions.IndexOf(replacedInstruction);
                    gameConsole.Instructions[index] = replacedInstruction is GameConsole.Jmp ?
                        new GameConsole.Nop() :
                        new GameConsole.Jmp { Argument = replacedInstruction.Argument };
                    nbIterations = 100;
                }

                gameConsole.Tick();
            }

            return gameConsole.Accumulator;
        }
    }
}