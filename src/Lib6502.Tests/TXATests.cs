using NUnit.Framework;

namespace Lib6502.Tests
{
    public class TXATests
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
        public void TXA()
        {

            sut.TXA();

            Assert.Inconclusive();
        }

    }
}
