
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class EORTests
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
        public void EOR_OneInAccumulatorAndTwoInMemory_ResultsInThreeInAccumulator()
        {
            sut.A = 0x01;
            sut.fetched = 0x02;

            sut.EOR();

            Assert.AreEqual(0x03, sut.A);
        }

        [Test]
        public void EOR_OneInAccumulatorAndOneInMemory_ResultsInZeroInAccumulator()
        {
            sut.A = 0x01;
            sut.fetched = 0x01;

            sut.EOR();

            Assert.AreEqual(0, sut.A);
        }

        [Test]
        public void EOR_OneTwentyEightInAccumulatorAndOneInMemory_ResultsInNegativeFlagSet()
        {
            sut.A = 0x80;
            sut.fetched = 0x01;

            sut.EOR();

            Assert.AreEqual(true, sut.N);
        }

    }
}
