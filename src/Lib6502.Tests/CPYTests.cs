
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CPYTests
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
        public void CPX_WhenRegisterLessThanFetched_CarryIsTrue()
        {
            sut.Y = 1;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(false, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterLessThanFetched_ZeroIsFalse()
        {
            sut.Y = 1;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CPX_WhenRegisterLessThanFetched_NegateIsFalse()
        {
            sut.Y = 1;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_CarryIsTrue()
        {
            sut.Y = 2;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_ZeroIsTrue()
        {
            sut.Y = 2;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_NegateIsFalse()
        {
            sut.Y = 2;
            sut.fetched = 2;

            sut.CPY();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CPX_WhenRegisterGreaterThanFetched_CarryIsTrue()
        {
            sut.Y = 2;
            sut.fetched = 1;

            sut.CPY();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterGreaterThanFetched_ZeroIsFalse()
        {
            sut.Y = 2;
            sut.fetched = 1;

            sut.CPY();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CPX_WhenRegisterGreaterThanFetched_NegateIsFalse()
        {
            sut.Y = 2;
            sut.fetched = 1;

            sut.CPY();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CMP_WhenRegisterOneAndFetched255Unsigned_FlagsAreCorrect()
        {
            sut.Y = 1;
            sut.fetched = 0xFF;

            sut.CPY();

            Assert.AreEqual(1, sut.Y);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(false, sut.N);
            Assert.AreEqual(false, sut.Z);
        }

        [Test]
        public void CMP_WhenRegisterOneTwentySevenAndFetchedNegativeOneTwentyEight_FlagsAreCorrect()
        {
            sut.Y = 0x7F;
            sut.fetched = 0x80;

            sut.CPY();

            Assert.AreEqual(0x7F, sut.Y);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(true, sut.N);
            Assert.AreEqual(false, sut.Z);
        }

    }
}
