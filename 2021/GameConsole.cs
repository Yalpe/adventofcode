using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using AdventOfCode;

namespace AdventOfCode
{
    public class GameConsole
    {
        private string[] _code;

        private Regex _codeRegex = new Regex(@"(\w{3})\s([\+-]?\d+)");

        public GameConsole(string[] code)
        {
            this._code = code;
            this.ParseCode();
        }

        public int InstructionPointer { get; set; }

        public int Accumulator { get; set; }

        public List<Instruction> Instructions = new List<Instruction>();

        public void ParseCode()
        {
            this.Accumulator = 0;
            this.InstructionPointer = 0;
            this.Instructions.Clear();
            foreach (var instruction in this._code)
            {
                var match = this._codeRegex.Match(instruction);
                switch (match.Groups[1].Value)
                {
                    case "nop":
                        this.Instructions.Add(new Nop());
                        break;
                    case "acc":
                        this.Instructions.Add(new Acc { Argument = int.Parse(match.Groups[2].Value) });
                        break;
                    case "jmp":
                        this.Instructions.Add(new Jmp { Argument = int.Parse(match.Groups[2].Value) });
                        break;
                }
            }
        }

        public void Tick()
        {
            if (this.InstructionPointer >= this._code.Length)
            {
                this.IsTerminated = true;
                return;
            }

            this.Instructions[this.InstructionPointer].Execute(this);
        }

        public bool IsTerminated { get; set; }

        public abstract class Instruction
        {
            public int Argument { get; set; }
            
            public abstract void Execute(GameConsole gameConsole);
        }

        public class Nop : Instruction
        {
            public override void Execute(GameConsole gameConsole)
            {
                ++gameConsole.InstructionPointer;
            }
        }

        public class Acc : Instruction
        {
            public override void Execute(GameConsole gameConsole)
            {
                gameConsole.Accumulator += this.Argument;
                ++gameConsole.InstructionPointer;
            }
        }

        public class Jmp : Instruction
        {
            public override void Execute(GameConsole gameConsole)
            {
                gameConsole.InstructionPointer += this.Argument;
            }
        }
    }
}