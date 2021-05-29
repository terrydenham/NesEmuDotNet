using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ROLTests
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
        public void ROL_WithHighOrderBit_MovesToCarry()
        {
            sut.CLC();

            sut.fetched = 0x80;

            sut.ROL();

            Assert.AreEqual(0, sut.fetched);
            
            m6502Tests.AssertFlags(sut, true, true);
        }

        #region Execute
        [Test]
        public void Execute_UsingAccumulator_TakesTwoClockCycles()
        {
            var code = "ROL A";
            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Execute_UsingZeroPage_TakesFiveClockCycles()
        {
            var code = "ROL $44";
            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void Execute_UsingZeroPageXIndexed_TakesSixClockCycles()
        {
            var code = "ROL $44,X";
            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void Execute_UsingAbsoluate_TakesSixClockCycles()
        {
            var code = "ROL $4400";
            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(6, actual);
        }

        [Test]
        public void Execute_UsingAbsoluateXIndexed_TakesSevenClockCycles()
        {
            var code = "ROL $4400,X";
            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(7, actual);
        }

        #endregion
    }
}
