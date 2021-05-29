using NUnit.Framework;

namespace Lib6502.Tests
{
    public class TSXTests
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
        public void TSX_MovesStackValueIntoRegisterIncrementsStackPointer()
        {
            byte expected = 0x23;

            sut.SP--;

            ushort oldSP = sut.SP;

            mem.Write(sut.SP, expected);

            sut.TSX();

            Assert.AreEqual(expected, sut.X);

            Assert.AreEqual(oldSP + 1, sut.SP);
        }

        [Test]
        public void TSX_TakesTwoClockCycles()
        {
            Assert.AreEqual(2, sut.TSX());
        }
    }
}
