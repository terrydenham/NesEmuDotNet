using NUnit.Framework;

namespace Lib6502.Tests
{
    public class DECTests
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
        public void Decrement_FromOne_ResultsInZeroFlagSet()
        {
            sut.addr_abs = 0x500;
            sut.fetched = 0x01;

            sut.DEC();

            Assert.AreEqual(0x00, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, true);
        }

        [Test]
        public void Decrement_FromTwo_ResultsInZeroFlagNotSet()
        {
            sut.addr_abs = 0x500;
            sut.fetched = 0x02;

            sut.DEC();

            Assert.AreEqual(0x01, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void Decrement_FromZero_ResultsInNegativeOneWithNegativeFlagSet()
        {
            sut.addr_abs = 0x500;
            sut.SetInitialState(CpuFlags.Z);
            sut.fetched = 0x00;

            sut.DEC();

            Assert.AreEqual(0xFF, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false, true);
        }

        [Test]
        public void Decrement_FromNegativeOne_ResultsInNegativeTwoWithNegativeFlagSet()
        {
            sut.addr_abs = 0x500;
            sut.SetInitialState(CpuFlags.N);
            sut.fetched = 0xFF;

            sut.DEC();

            Assert.AreEqual(0xFE, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false, true);
        }


    }
}
