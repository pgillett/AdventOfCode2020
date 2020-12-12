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

        private Registers FindAccumulator(CodeLine[] code)
        {
            var reg = new Registers();
            var seen = new bool[code.Length];
            while (!reg.InLoop && reg.ProgramCounter < code.Length)
            {
                if (seen[reg.ProgramCounter]) return reg.StuckInLoop();
                seen[reg.ProgramCounter] = true;
                reg = code[reg.ProgramCounter].Process(reg);
            }

            return reg;
        }

        public int FixAndAccumulator(string input)
        {
            var code = DecodeFile(input);

            for (int changeLine = 0; changeLine < code.Length; changeLine++)
            {
                code[changeLine].SwapNopJmp();
                var result = FindAccumulator(code);
                code[changeLine].SwapNopJmp();
                if (!result.InLoop) return result.Accumulator;
            }

            return 0;
        }

        private CodeLine[] DecodeFile(string input) => input
            .Split(Environment.NewLine)
            .Select(l => new CodeLine(l))
            .ToArray();

        public struct CodeLine
        {
            private string _opcode;
            private int _operand;

            public CodeLine(string code)
            {
                var instruction = code.Split(' ');
                _opcode = instruction[0];
                _operand = (instruction[1][0] == '+' ? 1 : -1) * int.Parse(instruction[1].Substring(1));
            }

            public CodeLine(string opcode, int operand)
            {
                _opcode = opcode;
                _operand = operand;
            }

            public void SwapNopJmp()
            {
                _opcode = _opcode switch
                {
                    "nop" => "jmp",
                    "jmp" => "nop",
                    _ => _opcode
                };
            }

            public Registers Process(Registers registers) =>
                _opcode switch
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
