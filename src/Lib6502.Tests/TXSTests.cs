using NUnit.Framework;

namespace Lib6502.Tests
{
    public class TXSTests
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
        public void TXS_MovesRegisterOnStackAndDecrementsStackPointer()
        {
            byte expected = 0x23;

            var oldSP = sut.SP;
            sut.X = expected;

            sut.TXS();

            Assert.AreEqual(expected, mem.Read((ushort)(sut.SP + 1)));

            Assert.AreEqual(oldSP - 1, sut.SP);
        }

        [Test]
        public void TXS_TakesTwoClockCycles()
        {
            Assert.AreEqual(2, sut.TXS());
        }
    }
}
