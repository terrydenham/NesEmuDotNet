using NUnit.Framework;

namespace Lib6502.Tests
{
    public class PLATests
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
        public void PLA_MovesStackValueIntoAccumulatorDecrementsStackPointer()
        {
            byte expected = 0x23;

            sut.SP--;

            ushort oldSP = sut.SP;

            mem.Write(sut.SP, expected);

            sut.PLA();

            Assert.AreEqual(expected, sut.A);

            Assert.AreEqual(oldSP + 1, sut.SP);
        }

        [Test]
        public void PLA_TakesFourClockCycles()
        {
            Assert.AreEqual(4, sut.PLA());
        }
    }
}
