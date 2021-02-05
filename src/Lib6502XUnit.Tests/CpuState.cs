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

        public byte SP { get; set; }

        public ushort PC { get; set; }
        public Action<Memory> MemoryCallback { get; set; }

        public CpuState(byte a, byte x, byte y, CpuFlags flags, Action<Memory> memoryCallback)
        {
            A = a;
            X = x;
            Y = y;
            Flags = flags;
            SP = (byte)0xFF;
            PC = (ushort)0x2000;
            MemoryCallback = memoryCallback;
        }

        public static CpuState Create(m6502 cpu)
        {
            return new CpuState(cpu.A, cpu.X, cpu.Y, cpu.Flags, null);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is CpuState))
                return false;

            var rhs = obj as CpuState;

            return this.A == rhs.A && this.X == rhs.X && this.Y == rhs.Y && this.Flags == rhs.Flags;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode() | X.GetHashCode() | Y.GetHashCode() | Flags.GetHashCode() | SP.GetHashCode() | PC.GetHashCode();
        }
    }
}
