using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ASLTests
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
        public void ASL_OneInFetched_ResultsInTwo()
        {
            sut.fetched = 0x01;

            sut.ASL();

            Assert.AreEqual(0x02, sut.fetched);
        }

        [Test]
        public void ASL_OneTwentyEightFetched_ResultsInCarrySet()
        {
            sut.fetched = 0x80;

            sut.ASL();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void ASL_OneTwentyEightFetched_ResultsInZeroSet()
        {
            sut.fetched = 0x80;

            sut.ASL();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void ASL_SixtyFourFetched_ResultsInNegativeFlagSet()
        {
            sut.fetched = 0b_0100_0000;

            sut.ASL();

            Assert.AreEqual(true, sut.N);
        }


    }
}
