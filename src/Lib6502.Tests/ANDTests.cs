using NUnit.Framework;

namespace Lib6502.Tests
{
    public class ANDTests
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
        public void And_ReturnsPostiveAdditionalCycles()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            var actual = sut.AND();

            Assert.AreEqual(1, actual);
        }

        [Test]
        public void And_ZeroAccumulatorZeroOperand_FlagsSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x00;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_ZeroAccumulatorNonZeroOperand_FlagsSet()
        {
            sut.A = 0x00;
            sut.fetched = 0x01;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_NonZeroAccumulatorZeroOperand_FlagsSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x00;

            sut.AND();

            Assert.AreEqual(0x00, sut.A);

            m6502Tests.AssertFlags(sut, false, true, false);
        }

        [Test]
        public void And_NonZeroAccumulatorNonZeroOperand_FlagsSet()
        {
            sut.A = 0x01;
            sut.fetched = 0x01;

            sut.AND();

            Assert.AreEqual(0x01, sut.A);

            m6502Tests.AssertFlags(sut, false, false, false);
        }
    }
}
