using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ANDTests
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
        public void And_ReturnsPostiveAdditionalCycles()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            var actual = sut.AND();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void And_ZeroAccumulatorZeroOperand_FlagsSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_ZeroAccumulatorNonZeroOperand_FlagsSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x01;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_NonZeroAccumulatorZeroOperand_FlagsSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x00;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_NonZeroAccumulatorNonZeroOperand_FlagsSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x01;

            sut.AND();

            Assert.AreEqual(0x01, sut.A);

            m6502Tests.AssertFlags(sut, false, false, false);
        }

        #region Execute Tests

        [Test]
        public void Execute_InImmedateMode_IsTwoCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND #$44"));

            var actual = sut.Execute();

            Assert.AreEqual(2, actual);
        }

        [Test]
        public void Execute_InZeroPage_IsThreeCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND $44"));

            var actual = sut.Execute();

            Assert.AreEqual(3, actual);
        }

        [Test]
        public void Execute_InZeroPageX_IsFourCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND $44,X"));

            var actual = sut.Execute();

            Assert.AreEqual(4, actual);
        }

        [Test]
        public void Execute_InAbsoluteNearAddress_IsFourCycles()
        {
            sut.PC = 0x100;

            ushort address = (ushort)(sut.PC + 0x100);

            var code = string.Format("AND $0200", address);
            var ml = Assembler.Assemble(code);

            mem.Write(sut.PC, ml);

            var actual = sut.Execute();

            Assert.AreEqual(4, actual);
        }

        [Test]
        public void Execute_InAbsoluteFarAddress_IsFourCycles()
        {
            sut.PC = 100;
            var address = sut.PC + 1000;

            var code = string.Format("AND ${0}", address);
            byte[] ml = Assembler.Assemble(code);
            mem.Write(sut.PC, ml);

            var actual = sut.Execute();

            Assert.AreEqual(4, actual);
        }

        [Test]
        public void Execute_InAbsoluteXNearAddress_IsFourCycles()
        {
            sut.PC = 0x100;

            var address = (sut.PC + 0xF0).ToString("X4");

            var code = string.Format("AND ${0},X", address);

            mem.Write(sut.PC, Assembler.Assemble(code));

            var actual = sut.Execute();

            Assert.AreEqual(4, actual);
        }

        [Test]
        public void Execute_InAbsoluteXFarAddress_IsFiveCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND $1100,X"));

            var actual = sut.Execute();

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void Execute_InIndirectX_IsSixCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND ($44,X)"));

            var actual = sut.Execute();

            Assert.AreEqual(6, actual);
        }


        [Test, Ignore("Not ready yet")]
        public void Execute_InIndirectYNearAddress_IsFiveCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND ($44),Y"));

            var actual = sut.Execute();

            Assert.AreEqual(5, actual);
        }

        [Test]
        public void Execute_InIndirectYFarAddress_IsSixCycles()
        {
            mem.Write(sut.PC, Assembler.Assemble("AND ($44),Y"));

            var actual = sut.Execute();

            Assert.AreEqual(6, actual);
        }

        #endregion
    }
}
