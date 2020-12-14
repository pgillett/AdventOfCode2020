using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Advent
{
    public class Day14
    {
        public long ValueAtLocation(string input, int memoryLocation)
        {
            return ProcessValueMask(input)[memoryLocation];
        }

        public long SumOfMemory(string input)
        {
            var memory = ProcessValueMask(input);

            return memory.Sum();
        }

        public long SumOfFloatingMemory(string input)
        {
            var memory = ProcessAddressMask(input);

            return memory.Sum();
        }

        private Memory ProcessValueMask(string input)
        {
            return ProcessInstructions(input,
                (memory, instruction, mask) =>
                {
                    var value = instruction.Value & mask.MaskAnd | mask.MaskOr;
                    memory[instruction.Location] = value;
                });
        }

        private Memory ProcessAddressMask(string input)
        {
            return ProcessInstructions(input,
                (memory, instruction, mask) =>
                {
                    var location = instruction.Location | mask.MaskOr;
                    memory.SetMemoryWithMask(mask, location, instruction.Value, 0);
                });
        }
        
        private Memory ProcessInstructions(string input, Action<Memory, Instruction, Mask> action)
        {
            var lines = input
                .Split(Environment.NewLine)
                .Select(l => new Instruction(l));

            var memory = new Memory();
            var mask = new Mask("");

            foreach (var line in lines)
            {
                if (line.IsMask)
                {
                    mask = line.Mask;
                }
                else
                {
                    action(memory, line, mask);
                }
            }

            return memory;
        }

        private class Instruction
        {
            public bool IsMask;
            public Mask Mask;
            public long Location;
            public long Value;

            public Instruction(string data)
            {
                var split = data
                    .Replace(" ", "")
                    .Split('[', ']', '=');
                IsMask = split[0] == "mask";
                Location = IsMask ? 0 : long.Parse(split[1]);
                Value = IsMask ? 0 : long.Parse(split[3]);
                Mask = IsMask ? new Mask(split[1]) : null;
            }
        }

        private class Mask
        {
            public long MaskOr;
            public long MaskAndX;
            public long MaskAnd => MaskAndX | MaskOr;
            public int Length;
            
            public Mask(string mask)
            {
                MaskAndX = 0L;
                MaskOr = 0L;
                Length = mask.Length;
                for (var i = 0; i < Length; i++)
                {
                    var bit = 1L << (Length - i - 1);
                    switch (mask[i])
                    {
                        case '1':
                            MaskOr |= bit;
                            break;
                        case 'X':
                            MaskAndX |= bit;
                            break;
                    }
                }
            }
        }

        private class Memory : Dictionary<long, long>
        {
            public long Sum() => Values.Sum();

            public void SetMemoryWithMask(Mask mask, long location, in long newValue, int bit)
            {
                if (bit == mask.Length) return;
                var flag = 1L << bit;
                if ((mask.MaskAndX & flag) != 0)
                {
                    this[location] = newValue;
                    this[location ^ flag] = newValue;
                    SetMemoryWithMask(mask, location, newValue, bit + 1);
                    SetMemoryWithMask(mask, location ^ flag, newValue, bit + 1);
                }
                else
                {
                    SetMemoryWithMask(mask, location, newValue, bit + 1);
                }
            }
        }

    }
}
