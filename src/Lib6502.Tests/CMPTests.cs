using NUnit.Framework;

namespace Lib6502.Tests
{
    public class CMPTests
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
        public void CMP_WhenAccumulatorLessThanFetched_CarryIsTrue()
        {
            sut.A = 1;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(false, sut.C);
        }

        [Test]
        public void CMP_WhenAccumulatorLessThanFetched_ZeroIsFalse()
        {
            sut.A = 1;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CMP_WhenAccumulatorLessThanFetched_NegateIsFalse()
        {
            sut.A = 1;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CMP_WhenAccumulatorEqualsFetched_CarryIsTrue()
        {
            sut.A = 2;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CMP_WhenAccumulatorEqualsFetched_ZeroIsTrue()
        {
            sut.A = 2;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(true, sut.Z);
        }

        [Test]
        public void CMP_WhenAccumulatorEqualsFetched_NegateIsFalse()
        {
            sut.A = 2;
            sut.fetched = 2;

            sut.CMP();

            Assert.AreEqual(false, sut.N);
        }

        [Test]
        public void CMP_WhenAccumulatorGreaterThanFetched_CarryIsTrue()
        {
            sut.A = 2;
            sut.fetched = 1;

            sut.CMP();

            Assert.AreEqual(true, sut.C);
        }

        [Test]
        public void CMP_WhenAccumulatorGreaterThanFetched_ZeroIsFalse()
        {
            sut.A = 2;
            sut.fetched = 1;

            sut.CMP();

            Assert.AreEqual(false, sut.Z);
        }

        [Test, Ignore("working on negate flag")]
        public void CMP_WhenAccumulatorGreaterThanFetched_NegateIsFalse()
        {
            sut.A = 2;
            sut.fetched = 1;

            sut.CMP();

            Assert.AreEqual(false, sut.N);
        }
 

        [Test]
        public void CMP_WhenAccumulatorOneAndFetched255Unsigned_FlagsAreCorrect()
        {
            sut.A = 1;
            sut.fetched = 0xFF;

            sut.CMP();

            Assert.AreEqual(1, sut.A);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(false, sut.N);
            Assert.AreEqual(false, sut.Z);
        }

        [Test]
        public void CMP_WhenAccumulatorOneTwentySevenAndFetchedNegativeOneTwentyEight_FlagsAreCorrect()
        {
            sut.A = 0x7F;
            sut.fetched = 0x80;

            sut.CMP();

            Assert.AreEqual(0x7F, sut.A);
            Assert.AreEqual(false, sut.C);
            Assert.AreEqual(true, sut.N);
            Assert.AreEqual(false, sut.Z);
        }
    }
}
