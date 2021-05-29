using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ADCTests
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
        public void AddWithCarry_ReturnsPositiveAdditionalCycles()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            var actual = sut.ADC();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void AddWithCarry_ZeroWithZeroWithZeroCarry_FlagsSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.ADC();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true);
        }

        [Test]
        public void AddWithCarry_TwoPositiveNumbersWithZeroCarry_HasNoCarry_FlagsSet()
        {
            sut.A = 0x20;
            sut.fetched = 0x03;

            sut.ADC();

            Assert.AreEqual(0x23, sut.A);

            m6502Tests.AssertFlags(sut, false, false);
        }

        [Test]
        public void AddWithCarry_TwoFiftyFiveAndOneWithZeroCarry_HasCarry_FlagsSet()
        {
            sut.CLC();
            sut.A = 0xFF;
            sut.fetched = 0x01;

            sut.ADC();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, true, true);
        }

        [Test]
        public void AddWithCarry_TwoFiftyFiveAndOneWithCarry_HasCarry_FlagsSet()
        {
            sut.SEC();
            sut.A = 0xFF;
            sut.fetched = 0x01;

            sut.ADC();

            Assert.AreEqual(0x01, sut.A);

            m6502Tests.AssertFlags(sut, true, false);
        }

        [Test]
        public void AddWithCarry_NegativeOneTwentyEightPlusNegativeOne_FlagsSet()
        {
            sut.A = 0x7F;
            sut.fetched = 0x01;

            sut.ADC();

            Assert.AreEqual(0x80, sut.A);

            m6502Tests.AssertFlags(sut, false, false, true, false);
        }

}
}
