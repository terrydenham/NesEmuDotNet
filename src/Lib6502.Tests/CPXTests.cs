
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CPXTests
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
            sut.X = 1;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(false, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterLessThanFetched_ZeroIsFalse()
        {
            sut.X = 1;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CPX_WhenRegisterLessThanFetched_NegateIsFalse()
        {
            sut.X = 1;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_CarryIsTrue()
        {
            sut.X = 2;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_ZeroIsTrue()
        {
            sut.X = 2;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void CPX_WhenRegisterEqualsFetched_NegateIsFalse()
        {
            sut.X = 2;
            sut.fetched = 2;

            sut.CPX();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CPX_WhenRegisterGreaterThanFetched_CarryIsTrue()
        {
            sut.X = 2;
            sut.fetched = 1;

            sut.CPX();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CPX_WhenRegisterGreaterThanFetched_ZeroIsFalse()
        {
            sut.X = 2;
            sut.fetched = 1;

            sut.CPX();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CPX_WhenRegisterGreaterThanFetched_NegateIsFalse()
        {
            sut.X = 2;
            sut.fetched = 1;

            sut.CPX();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CMP_WhenRegisterOneAndFetched255Unsigned_FlagsAreCorrect()
        {
            sut.X = 1;
            sut.fetched = 0xFF;

            sut.CPX();

            Assert.AreEqual(1, sut.X);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(false, sut.N);
            Assert.AreEqual(false, sut.Z);
        }

        [Test]
        public void CMP_WhenRegisterOneTwentySevenAndFetchedNegativeOneTwentyEight_FlagsAreCorrect()
        {
            sut.X = 0x7F;
            sut.fetched = 0x80;

            sut.CPX();

            Assert.AreEqual(0x7F, sut.X);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(true, sut.N);
            Assert.AreEqual(false, sut.Z);
        }

    }
}
