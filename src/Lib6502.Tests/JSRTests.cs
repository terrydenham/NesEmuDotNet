
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class JSRTests
    {
        protected Memory mem;
        protected m6502 sut;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            mem = new Memory(1024 * 32);
            sut = new m6502(mem);
        }

        [SetUp]
        public void Setup()
        {
            mem.Clear();
            sut.Reset();
        }

        [Test]
        public void JSR_WithProgramCounterOneThousandAndTwo_ProgramCounterAddressIsPushedOntoStack()
        {
            // this represents the current program instruction
            sut.PC = 0x1002;

            // this represents the address read from memory, the jump to address
            sut.addr_abs = 0x4000;

            sut.JSR();

            byte hi = mem.Read((ushort)(sut.SP + 1));
            byte lo = mem.Read((ushort)(sut.SP + 2));

            ushort lastAddress = (ushort)((hi << 8) + lo);

            // verify that the program counter address is pushed onto the stack
            // so that when we return from subroutine, we will pop the return
            // address off the stack
            Assert.AreEqual(0x1002, lastAddress);
        }

    }
}
