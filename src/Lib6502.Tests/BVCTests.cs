using NUnit.Framework;

namespace Lib6502.Tests
{
    public class BVCTests
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
        public void BVC_WithOverflowSet_ProgramCounterStaysTheSame()
        {
            sut.PC = 0x1000;

            // set the overflow flag
            sut.SetInitialState(CpuFlags.V);

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x1050;

            var expected = sut.Cycles;

            // Act
            sut.BVC();

            Assert.AreEqual(0x1000, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }

        [Test]
        public void BVC_WithOverflowSetAndOnPageAddress_ProgramCounterChanges()
        {
            sut.PC = 0x1000;

            // clear the overflow flag
            sut.CLV();

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x0050;

            var expected = sut.Cycles + 1;

            // Act
            sut.BVC();

            Assert.AreEqual(0x1050, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }

        [Test]
        public void BVC_WithOverflowSetAndOffPageAddress_ProgramCounterChanges()
        {
            sut.PC = 0x1000;

            // clear the overflow flag
            sut.CLV();

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x2000;

            var expected = sut.Cycles + 2;

            // Act
            sut.BVC();

            Assert.AreEqual(0x3000, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }
    }
}
