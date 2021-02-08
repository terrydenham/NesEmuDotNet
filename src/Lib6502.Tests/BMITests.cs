using NUnit.Framework;

namespace Lib6502.Tests
{
    public class BMITests
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
        public void BMI_WithNegativeNotSet_ProgramCounterStaysTheSame()
        {
            sut.PC = 0x1000;

            // clear the negative flag
            sut.SetInitialState(CpuFlags.Empty);

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x1050;

            var expected = sut.Cycles;

            // Act
            sut.BMI();

            Assert.AreEqual(0x1000, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }

        [Test]
        public void BMI_WithNegativeSetAndOnPageAddress_ProgramCounterChanges()
        {
            sut.PC = 0x1000;

            // set the negative flag
            sut.SetInitialState(CpuFlags.N);

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x0050;

            var expected = sut.Cycles + 1;

            // Act
            sut.BMI();

            Assert.AreEqual(0x1050, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }

        [Test]
        public void BMI_WithNegativeSetAndOffPageAddress_ProgramCounterChanges()
        {
            sut.PC = 0x1000;

            // set the negative flag
            sut.SetInitialState(CpuFlags.N);

            // set the relative address on the same page (within 255 bytes)
            sut.addr_rel = 0x2000;

            var expected = sut.Cycles + 2;

            // Act
            sut.BMI();

            Assert.AreEqual(0x3000, sut.PC);
            Assert.AreEqual(expected, sut.Cycles);
        }
    }
}
