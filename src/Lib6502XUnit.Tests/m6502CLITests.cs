using System;
using Xunit;
using System.Collections.Generic;
using Lib6502;

namespace Lib6502XUnit.Tests
{
    public class m6502CLITests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ClearInterrupt(string[] instructions, byte a, byte x, byte y, CpuFlags initialFlags, byte expectedValue, byte expectedCycles, CpuFlags expectedFlags, Action<Memory> memoryCallback)
        {
            var mem = new Memory(1024 * 32);

            memoryCallback?.Invoke(mem);

            var codeBytes = Assembler.Assemble(instructions);

            var sut = new m6502(mem);

            mem.Write(sut.PC, codeBytes);
            sut.A = a;
            sut.X = x;
            sut.Y = y;
            sut.SetInitialState(initialFlags);

            sut.Clock();
            Assert.Equal(expectedCycles, sut.Cycles + 1);

            sut.Run();

            Assert.Equal(expectedValue, sut.A);
            Helper.AssertFlags(sut, expectedFlags);

        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
//                new object[] { new string[] { "CLI #$44" }, 0x01, CpuFlags.Empty, 0x45, CpuFlags.Empty, (Action<Memory>) ((m) => { m.Write(0x0000, 0x01); } ) },
                new object[] { new string[] { "CLI         " }, 0x00, 0x00, 0x00, CpuFlags.Empty, 0x00, 2, CpuFlags.Empty, null},
                new object[] { new string[] { "CLI         " }, 0x00, 0x00, 0x00, CpuFlags.I    , 0x00, 2, CpuFlags.Empty, null},
            };
    }
}
