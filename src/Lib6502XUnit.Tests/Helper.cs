using Lib6502;
using Xunit;

namespace Lib6502XUnit.Tests
{
    public static class Helper
    {
        public static void AssertFlags(m6502 sut, CpuFlags expectedFlags)
        {
            Assert.True(((expectedFlags & CpuFlags.B) == CpuFlags.B) == sut.B, "Break flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.C) == CpuFlags.C) == sut.C, "Carry flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.D) == CpuFlags.D) == sut.D, "Decimal flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.I) == CpuFlags.I) == sut.I, "Interrupt flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.N) == CpuFlags.N) == sut.N, "Negative flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.U) == CpuFlags.U) == sut.U, "Unused flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.V) == CpuFlags.V) == sut.V, "Overflow flag was not correct");
            Assert.True(((expectedFlags & CpuFlags.Z) == CpuFlags.Z) == sut.Z, "Zero flag was not correct");
        }
    }
}
