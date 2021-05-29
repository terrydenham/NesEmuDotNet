using NUnit.Framework;

namespace Lib6502.Tests
{
    public class PHATests
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
        public void PHA_MovesAccumulatorOntoStackDecrementsStackPointer()
        {
            byte expected = 0x23;

            ushort oldSP = sut.SP;

            sut.A = expected;

            sut.PHA();

            Assert.AreEqual(expected, mem.Read(oldSP));

            Assert.AreEqual(oldSP - 1, sut.SP);
        }

        [Test]
        public void PHA_TakesThreeClockCycles()
        {
            Assert.AreEqual(3, sut.PHA());
        }
    }
}
