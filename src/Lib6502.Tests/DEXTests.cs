using NUnit.Framework;

namespace Lib6502.Tests
{
    public class DEXTests
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
            sut.X = 0x01;

            sut.DEX();

            Assert.AreEqual(0x00, sut.X);

            m6502Tests.AssertFlags(sut, false, true);
        }

        [Test]
        public void Decrement_FromTwo_ResultsInZeroFlagNotSet()
        {
            sut.X = 0x02;

            sut.DEX();

            Assert.AreEqual(0x01, sut.X);

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void Decrement_FromZero_ResultsInNegativeOneWithNegativeFlagSet()
        {
            sut.SetInitialState(CpuFlags.Z);
            sut.X = 0x00;

            sut.DEX();

            Assert.AreEqual(0xFF, sut.X);

            m6502Tests.AssertFlags(sut, false, false, true);
        }

        [Test]
        public void Decrement_FromNegativeOne_ResultsInNegativeTwoWithNegativeFlagSet()
        {
            sut.SetInitialState(CpuFlags.N);
            sut.X = 0xFF;

            sut.DEX();

            Assert.AreEqual(0xFE, sut.X);

            m6502Tests.AssertFlags(sut, false, false, true);
        }


    }
}
