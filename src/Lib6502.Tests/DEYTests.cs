using NUnit.Framework;

namespace Lib6502.Tests
{
    public class DEYTests
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
            sut.Y = 0x01;

            sut.DEY();

            Assert.AreEqual(0x00, sut.Y);

            m6502Tests.AssertFlags(sut, false, true);
        }

        [Test]
        public void Decrement_FromTwo_ResultsInZeroFlagNotSet()
        {
            sut.Y = 0x02;

            sut.DEY();

            Assert.AreEqual(0x01, sut.Y);

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void Decrement_FromZero_ResultsInNegativeOneWithNegativeFlagSet()
        {
            sut.SetInitialState(CpuFlags.Z);
            sut.Y = 0x00;

            sut.DEY();

            Assert.AreEqual(0xFF, sut.Y);

            m6502Tests.AssertFlags(sut, false, false, true);
        }

        [Test]
        public void Decrement_FromNegativeOne_ResultsInNegativeTwoWithNegativeFlagSet()
        {
            sut.SetInitialState(CpuFlags.N);
            sut.Y = 0xFF;

            sut.DEY();

            Assert.AreEqual(0xFE, sut.Y);

            m6502Tests.AssertFlags(sut, false, false, true);
        }


    }
}
