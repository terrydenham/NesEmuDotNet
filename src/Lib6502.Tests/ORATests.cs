
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ORATests
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
        public void ORA_ZeroInAccumulatorNonZeroInMemory_ResultsInNonZeroInAccumulator()
        {
            sut.A = 0x00;
            sut.fetched = 0x01;

            sut.ORA();

            Assert.AreEqual(0x01, sut.A);
        }

        [Test]
        public void ORA_NonZeroInAccumulatorZeroInMemory_ResultsInNonZeroInAccumulator()
        {
            sut.A = 0x01;
            sut.fetched = 0x00;

            sut.ORA();

            Assert.AreEqual(0x01, sut.A);
        }

        [Test]
        public void ORA_ZeroInAccumulatorZeroInMemory_ResultsInZeroInAccumulator()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.ORA();

            Assert.AreEqual(0, sut.A);
        }

        [Test]
        public void ORA_NonZeroInAccumulatorNonZeroInMemory_ResultsInNonZeroInAccumulator()
        {
            sut.A = 0x01;
            sut.fetched = 0x01;

            sut.ORA();

            Assert.AreEqual(1, sut.A);
        }

        [Test]
        public void ORA_ZeroInAccumulatorZeroInMemory_ResultsInZeroFlagSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.ORA();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void ORA_HighBitSetInAccumulatorHighBitNotSetInMemory_ResultsInNegativeFlagSet()
        {
            sut.A = 0b_1000_0000;
            sut.fetched = 0x0;

            sut.ORA();

            Assert.AreEqual(true, sut.N);
        }

    }
}
