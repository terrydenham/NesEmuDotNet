using NUnit.Framework;

namespace Lib6502.Tests
{
    public class INCTests
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
        public void Increment_FromZero_ResultsInZeroFlagNotSet()
        {
            sut.SetInitialState(CpuFlags.Z);
            sut.addr_abs = 0x500;
            sut.fetched = 0x00;

            sut.INC();

            Assert.AreEqual(0x01, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void Increment_FromOne_ResultsInZeroFlagNotSet()
        {
            sut.addr_abs = 0x500;
            sut.fetched = 0x01;

            sut.INC();

            Assert.AreEqual(0x02, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void Increment_FromNegativeOne_ResultsInZeroWithZeroFlagSetAndNegativeFlagNotSet()
        {
            sut.addr_abs = 0x500;
            sut.SetInitialState(CpuFlags.N);
            sut.fetched = 0xFF;

            sut.INC();

            Assert.AreEqual(0x00, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void Increment_FromNegativeTwo_ResultsInNegativeOneWithNegativeFlagSet()
        {
            sut.addr_abs = 0x500;
            sut.SetInitialState(CpuFlags.N);
            sut.fetched = 0xFE;

            sut.INC();

            Assert.AreEqual(0xFF, mem.Read(sut.addr_abs));

            m6502Tests.AssertFlags(sut, false, false, true);
        }
    }
}
