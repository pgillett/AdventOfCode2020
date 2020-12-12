using System;
using System.Linq;

namespace Advent
{
    public class Day08
    {
        public int AccumulateAtCrash(string input)
        {
            var code = DecodeFile(input);

            return FindAccumulator(code).Accumulator;
        }

        private Registers FindAccumulator(CodeLine[] code, int swapLine = -1)
        {
            var reg = new Registers();
            var seen = new bool[code.Length];
            while (!reg.InLoop && reg.ProgramCounter < code.Length)
            {
                if (seen[reg.ProgramCounter]) return reg.StuckInLoop();
                seen[reg.ProgramCounter] = true;
                reg = code[reg.ProgramCounter].Process(reg, reg.ProgramCounter == swapLine);
            }

            return reg;
        }

        public int FixAndAccumulator(string input)
        {
            var code = DecodeFile(input);

            return code.Select((_, changeLine) => FindAccumulator(code, changeLine))
                    .Where(result => !result.InLoop)
                    .Select(result => result.Accumulator)
                .FirstOrDefault();
        }

        private CodeLine[] DecodeFile(string input) => input
            .Split(Environment.NewLine)
            .Select(l => new CodeLine(l))
            .ToArray();

        public struct CodeLine
        {
            private readonly string _opcode;
            private readonly int _operand;

            public CodeLine(string code)
            {
                var instruction = code.Split(' ');
                _opcode = instruction[0];
                _operand = int.Parse(instruction[1]);
            }

            private string SwapNopJmp(string opcode) =>
                opcode switch
                {
                    "nop" => "jmp",
                    "jmp" => "nop",
                    _ => opcode
                };

            public Registers Process(Registers registers, bool swapLine) =>
                (swapLine ? SwapNopJmp(_opcode) : _opcode) switch
                {
                    "jmp" => registers.AddPC(_operand),
                    "acc" => registers.AddAccumulator(_operand).AddPC(1),
                    _ => registers.AddPC(1)
                };
        }

        public struct Registers
        {
            public readonly int ProgramCounter;
            public readonly int Accumulator;
            public readonly bool InLoop;

            public Registers(int programCounter, int accumulator, bool inLoop = false)
            {
                ProgramCounter = programCounter;
                Accumulator = accumulator;
                InLoop = inLoop;
            }

            public Registers AddPC(int value) => new Registers(ProgramCounter + value, Accumulator);
            public Registers AddAccumulator(int value) => new Registers(ProgramCounter, Accumulator + value);
            public Registers StuckInLoop() => new Registers(ProgramCounter, Accumulator, true);
        }
    }
}
