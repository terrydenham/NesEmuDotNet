
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class LSRTests
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
        public void LSR_FetchedOneValue_ResultsInZeroValue()
        {
            sut.fetched = 0x01;

            sut.LSR();

            Assert.AreEqual(0x00, sut.A);
        }

        [Test]
        public void LSR_FetchedOneValue_ResultsInZeroFlag()
        {
            sut.fetched = 0x01;

            sut.LSR();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void LSR_FetchedOneValue_ResultsInCarryFlag()
        {
            sut.fetched = 0x01;

            sut.LSR();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void LSR_FetchedOneValue_ResultsInNegativeFlagNotSet()
        {
            sut.fetched = 0x01;

            sut.LSR();

            Assert.AreEqual(false, sut.N);
        }

    }
}
