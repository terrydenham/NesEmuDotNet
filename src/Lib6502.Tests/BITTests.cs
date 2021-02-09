using NUnit.Framework;

namespace Lib6502.Tests
{
    public class BITTests
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
        public void BIT_ReturnsZeroAdditionalCycles()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            byte actual = sut.BIT();

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void BIT_WithZeroAccumulatorAndZeroOperand_ResultsInZeroFlagSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.BIT();

            Assert.True(sut.Z);
        }

        [Test]
        public void BIT_WithZeroAccumulatorAndNonZeroOperand_ResultsInZeroFlagNotSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x01;

            sut.BIT();

            Assert.True(sut.Z);
        }

        [Test]
        public void BIT_WithNonZeroAccumulatorAndZeroOperand_ResultsInZeroFlagNotSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x00;

            sut.BIT();

            Assert.True(sut.Z);
        }

        [Test]
        public void BIT_WithNonZeroAccumulatorAndNonZeroOperand_ResultsInZeroFlagNotSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x01;

            sut.BIT();

            Assert.False(sut.Z);
        }
    }
}
