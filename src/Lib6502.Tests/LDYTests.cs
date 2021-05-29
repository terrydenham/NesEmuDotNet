
using NUnit.Framework;

namespace Lib6502.Tests
{
    public class LDYTests
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
        public void LDY_WithValueOneFetched_RegisterIsOne()
        {
            sut.fetched = 0x01;

            sut.LDY();

            Assert.AreEqual(0x01, sut.Y);
        }

    }
}
