using Lib6502;
using System;

namespace Lib6502XUnit.Tests
{
    public class CpuState
    {
        public byte A { get; set; }
        public byte X { get; set; }
        public byte Y { get; set; }
        public CpuFlags Flags { get; set; }
        public Action<Memory> MemoryCallback { get; set; }

        public CpuState(byte a, byte x, byte y, CpuFlags flags, Action<Memory> memoryCallback)
        {
            A = a;
            X = x;
            Y = y;
            Flags = flags;
            MemoryCallback = memoryCallback;
        }
    }
}
